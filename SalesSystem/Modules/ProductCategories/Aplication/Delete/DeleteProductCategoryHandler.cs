using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;

namespace SalesSystem.Modules.ProductCategories.Aplication.Delete
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public DeleteProductCategoryHandler(IUnitOfWork unitOfWork, IProductCategoryRepository productCategoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productCategoryRepository = productCategoryRepository ?? throw new ArgumentNullException(nameof(productCategoryRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await _productCategoryRepository.ProductCategoryExistAsync(new ProductId(request.ProductId), new CategoryId(request.CategoriesId));
            if (productCategory is not null)
            {
                _productCategoryRepository.Delete(productCategory);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
