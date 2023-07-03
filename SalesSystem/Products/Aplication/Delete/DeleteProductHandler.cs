using SalesSystem.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Products.Domain.DomainErrors;

namespace SalesSystem.Products.Aplication.Delete
{
    internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (await _productRepository.GetByIdAsync(new ProductId(request.Id)) is not Product productBd)
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

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
