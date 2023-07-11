using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.Categories.Domain.DomainErrors;

namespace SalesSystem.Modules.Categories.Aplication.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            if (await _unitOfWork.CategoryRepository.GetByIdAsync(new CategoryId(request.Id)) is not Category categoryDb)
                return ErrosCategory.NotFoundCategory;

            if (categoryDb.Name == request.Name)
                return Unit.Value;

            if(await _unitOfWork.CategoryRepository.GetByNameAsync(request.Name) is not null)
                return ErrosCategory.CategoryNameAlreadyExist;

            Category category = Category.UpdateCategory
                (
                    request.Id,
                    request.Name,
                    categoryDb.CreateAt,
                    DateTime.UtcNow,
                    categoryDb.DeleteAt,
                    true,
                    categoryDb.IsDeleted
                );

            _unitOfWork.CategoryRepository.Update(category);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
