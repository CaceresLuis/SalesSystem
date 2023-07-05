using SalesSystem.Modules.Categories.Domain.Dto;

namespace SalesSystem.Modules.Categories.Aplication.GetAll
{
    public record GetAllCategoriesQuery() : IRequest<ErrorOr<IReadOnlyList<CategoryResponseDto>>>;


}
