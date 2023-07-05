using SalesSystem.Products.Domain;
using SalesSystem.Categories.Domain;
using SalesSystem.ProductCategories.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.ProductCategories.Aplication.Create
{
    public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductCategoryHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, ICategoryRepository categoryRepository, IProductCategoryRepository productCategoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _productCategoryRepository = productCategoryRepository ?? throw new ArgumentNullException(nameof(productCategoryRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(new ProductId(request.ProductId));
            if (product is not null)
            {
                foreach (Guid category in request.CategoriesId)
                {
                    Category? categoryDb = await _categoryRepository.GetByIdAsync(new CategoryId(category));
                    if (categoryDb is not null)
                    {
                        ProductCategory productCategory = new
                            (
                                0,
                                categoryDb.Id!,
                                product.Id!
                            );

                        if (!await _productCategoryRepository.ProductCategoryRelationExistAsync(product.Id!, categoryDb.Id!))
                            _productCategoryRepository.Add(productCategory);
                    }
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
