using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.Products.Aplication.Delete
{
    internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.GetByIdAsync(new ProductId(request.Id)) is not Product productBd)
                return ErrorsProduct.NotFoundProduct;

            Product product = Product.UpdateProduct
                (
                    request.Id,
                    productBd.Name,
                    productBd.Description,
                    productBd.Price,
                    productBd.Stock,
                    productBd.CreateAt,
                    productBd.UpdateAt,
                    DateTime.UtcNow,
                    productBd.IsUpdated,
                    true
                );

            _unitOfWork.ProductRepository.Update(product);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
