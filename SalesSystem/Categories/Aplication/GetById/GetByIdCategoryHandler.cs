using SalesSystem.Categories.Domain;
using SalesSystem.Categories.Domain.DomainErrors;
using SalesSystem.Categories.Domain.Dto;

namespace SalesSystem.Categories.Aplication.GetById
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, ErrorOr<CategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<ErrorOr<CategoryResponseDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.GetByIdAsync(new CategoryId(request.Id)) is not Category category)
                return ErrosCategory.NotFoundCategory;

            return new CategoryResponseDto
            (
                category.Id!.Value,
                category.Name,
                category.CreateAt,
                category.UpdateAt,
                category.DeleteAt,
                category.IsUpdated,
                category.IsDeleted
            );
        }
    }
}
