using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Images.Domain;

namespace SalesSystem.Modules.Products.Aplication.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new
                (
                    new ProductId(Guid.NewGuid()),
                    request.Name,
                    request.Description,
                    request.Price,
                    request.Stock,
                    DateTime.UtcNow,
                    DateTime.MinValue,
                    DateTime.MinValue,
                    false,
                    false
                );

            _unitOfWork.ProductRepository.Add(product);

            if (request.Categories is not null)
            {
                foreach (Guid category in request.Categories)
                {
                    if (await _unitOfWork.CategoryRepository.GetByIdAsync(new CategoryId(category)) is Category categoryDb)
                    {
                        ProductCategory productCategory = new
                            (
                                0,
                                categoryDb.Id!,
                                product.Id!
                            );

                        _unitOfWork.ProductCategoryRepository.Add(productCategory);
                    }
                }
            }

            if (request.File != null)
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
