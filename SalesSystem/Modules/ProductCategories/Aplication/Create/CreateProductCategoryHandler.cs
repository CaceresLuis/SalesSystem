using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.ProductCategories.Aplication.Create
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

            List<Guid> listCategories = request.CategoriesId.GroupBy(c => c).Where(a => a.Count() > 1).Select(a => a.Key).ToList();
            foreach (Guid cat in listCategories)
            {
                request.CategoriesId.Remove(cat);
            }

            if (await _productRepository.GetByIdAsync(new ProductId(request.ProductId)) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            foreach (Guid category in request.CategoriesId)
            {
                if (await _categoryRepository.GetByIdAsync(new CategoryId(category)) is Category categoryDb)
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

            return Unit.Value;
        }
    }
}
