using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.Primitives;

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
