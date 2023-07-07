using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;

namespace SalesSystem.Modules.Products.Aplication.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _productCategoryRepository = productCategoryRepository ?? throw new ArgumentNullException(nameof(productCategoryRepository));
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

            if (request.Categories is not null)
            {
                foreach (Guid category in request.Categories)
                {
                    if (await _categoryRepository.GetByIdAsync(new CategoryId(category)) is Category categoryDb)
                    {
                        ProductCategory productCategory = new
                            (
                                0,
                                categoryDb.Id!,
                                product.Id!
                            );

                        _productCategoryRepository.Add(productCategory);
                    }
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
