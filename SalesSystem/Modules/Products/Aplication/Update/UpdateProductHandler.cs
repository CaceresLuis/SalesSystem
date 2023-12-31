﻿using SalesSystem.Modules.Images.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.Products.Aplication.Update
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.GetByIdAsync(new ProductId(request.Id)) is not Product productBd)
                return ErrorsProduct.NotFoundProduct;

            Product product = Product.UpdateProduct
                (
                    request.Id,
                    string.IsNullOrEmpty(request.Name) ? productBd.Name : request.Name,
                    string.IsNullOrEmpty(request.Description) ? productBd.Description : request.Description,
                    request.Price,
                    request.Stock,
                    productBd.CreateAt,
                    DateTime.UtcNow,
                    productBd.DeleteAt,
                    true,
                    productBd.IsDeleted
                );

            _unitOfWork.ProductRepository.Update(product);

            if(request.File != null)
            {
                Stream file = request.File.OpenReadStream();
                FirebaseImage firebaseImage = new()
                {
                    File = file,
                    Folder = "Product",
                    Name = Guid.NewGuid().ToString(),
                };

                string imageUrl = await _unitOfWork.ImagenRepository.UploadImageAsync(firebaseImage);

                Image image = new()
                {
                    Id = Guid.NewGuid(),
                    ImageUrl = imageUrl,
                    ProductId = product.Id
                };

                _unitOfWork.ImagenRepository.Add(image);
            }

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
