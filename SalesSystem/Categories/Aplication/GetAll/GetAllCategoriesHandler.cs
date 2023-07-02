using ErrorOr;
using MediatR;
using SalesSystem.Categories.Domain;
using SalesSystem.Categories.Aplication.Dto;

namespace SalesSystem.Categories.Aplication.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ErrorOr<IReadOnlyList<CategoryResponseDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<CategoryResponseDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();

            return categories.Select(category => new CategoryResponseDto
            (
                category.Id.Value,
                category.Name,
                category.CreateAt
            )).ToList();
        }
    }
}
