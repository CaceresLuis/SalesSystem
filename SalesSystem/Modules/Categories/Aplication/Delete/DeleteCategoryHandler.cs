using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.Categories.Domain.DomainErrors;

namespace SalesSystem.Modules.Categories.Aplication.Delete
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CategoryRepository.GetByIdAsync(new CategoryId(request.Id)) is not Category categoryDb)
                return ErrosCategory.NotFoundCategory;

            Category category = Category.UpdateCategory
                (
                    categoryDb.Id!.Value,
                    categoryDb.Name,
                    categoryDb.CreateAt,
                    categoryDb.UpdateAt,
                    DateTime.UtcNow,
                    categoryDb.IsUpdated,
                    true
                );

            _unitOfWork.CategoryRepository.Update(category);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
