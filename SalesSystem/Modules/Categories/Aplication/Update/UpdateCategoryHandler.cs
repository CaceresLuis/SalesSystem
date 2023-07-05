using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Categories.Domain.DomainErrors;

namespace SalesSystem.Modules.Categories.Aplication.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.GetByIdAsync(new CategoryId(request.Id)) is not Category categoryDb)
                return ErrosCategory.NotFoundCategory;

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

            _categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
