using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Categories.Domain.DomainErrors;

namespace SalesSystem.Modules.Categories.Aplication.Create
{
    public sealed class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.GetByNameAsync(request.Name) is not null)
                return ErrosCategory.CategoryNameAlreadyExist;

            Category category = new
                (
                    new CategoryId(Guid.NewGuid()),
                    request.Name,
                    DateTime.UtcNow,
                    DateTime.MinValue,
                    DateTime.MinValue,
                    false,
                    false
                );

            _categoryRepository.Add(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
