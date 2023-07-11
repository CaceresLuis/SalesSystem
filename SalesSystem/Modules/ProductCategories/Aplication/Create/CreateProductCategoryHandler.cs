using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.ProductCategories.Aplication.Create
{
    public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {

            List<Guid> listCategories = request.CategoriesId.GroupBy(c => c).Where(a => a.Count() > 1).Select(a => a.Key).ToList();
            foreach (Guid cat in listCategories)
            {
                request.CategoriesId.Remove(cat);
            }

            if (await _unitOfWork.ProductRepository.GetByIdAsync(new ProductId(request.ProductId)) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            foreach (Guid category in request.CategoriesId)
            {
                if (await _unitOfWork.CategoryRepository.GetByIdAsync(new CategoryId(category)) is Category categoryDb)
                {
                    ProductCategory productCategory = new
                    (
                        0,
                        categoryDb.Id!,
                        product.Id!
                    );

                    if (!await _unitOfWork.ProductCategoryRepository.ProductCategoryRelationExistAsync(product.Id!, categoryDb.Id!))
                        _unitOfWork.ProductCategoryRepository.Add(productCategory);
                }
            }

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
