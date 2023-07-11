using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.Categories.Domain.DomainErrors;

namespace SalesSystem.Modules.Categories.Aplication.Create
{
    public sealed class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CategoryRepository.GetByNameAsync(request.Name) is not null)
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

            _unitOfWork.CategoryRepository.Add(category);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
