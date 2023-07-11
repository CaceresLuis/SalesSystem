using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Categories.Domain.Dto;

namespace SalesSystem.Modules.Categories.Aplication.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ErrorOr<IReadOnlyList<CategoryResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<CategoryResponseDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Category> categories = await _unitOfWork.CategoryRepository.GetAllAsync();

            return categories.Select(category => new CategoryResponseDto
            (
                category.Id!.Value,
                category.Name,
                category.CreateAt,
                category.UpdateAt,
                category.DeleteAt,
                category.IsUpdated,
                category.IsDeleted
            )).ToList();
        }
    }
}
