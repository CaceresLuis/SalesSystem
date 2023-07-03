using SalesSystem.Categories.Domain.Dto;

namespace SalesSystem.Categories.Aplication.GetAll
{
    public record GetAllCategoriesQuery() : IRequest<ErrorOr<IReadOnlyList<CategoryResponseDto>>>;


}
