using ErrorOr;
using MediatR;
using SalesSystem.Categories.Aplication.Dto;

namespace SalesSystem.Categories.Aplication.GetAll
{
    public record GetAllCategoriesQuery() : IRequest<ErrorOr<IReadOnlyList<CategoryResponseDto>>>;


}
