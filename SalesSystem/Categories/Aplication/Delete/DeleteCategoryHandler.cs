using SalesSystem.Categories.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Categories.Domain.DomainErrors;

namespace SalesSystem.Categories.Aplication.Delete
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.GetByIdAsync(new CategoryId(request.Id)) is not Category categoryDb)
                return ErrosCategory.NotFoundCategory;

            Category category = Category.DeleteCategory
                (
                    categoryDb.Id.Value,
                    categoryDb.Name,
                    categoryDb.CreateAt,
                    categoryDb.UpdateAt,
                    DateTime.UtcNow,
                    categoryDb.IsUpdated,
                    true
                );

            _categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
