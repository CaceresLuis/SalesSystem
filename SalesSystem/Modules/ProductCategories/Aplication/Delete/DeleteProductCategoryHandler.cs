using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.ProductCategories.Domain.DomainErrors;

namespace SalesSystem.Modules.ProductCategories.Aplication.Delete
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductCategoryRepository.ProductCategoryExistAsync(new ProductId(request.ProductId), new CategoryId(request.CategoriesId)) is not ProductCategory productCategory)
                return ErrorProductCategory.NotFoundProductCategoryRelation;

            _unitOfWork.ProductCategoryRepository.Delete(productCategory);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
