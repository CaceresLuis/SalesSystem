using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Categories.Domain.Dto;
using SalesSystem.Modules.Categories.Domain.DomainErrors;

namespace SalesSystem.Modules.Categories.Aplication.GetById
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, ErrorOr<CategoryResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<CategoryResponseDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CategoryRepository.GetByIdAsync(new CategoryId(request.Id)) is not Category category)
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
