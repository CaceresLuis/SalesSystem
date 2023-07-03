using SalesSystem.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Products.Aplication.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
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

            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
