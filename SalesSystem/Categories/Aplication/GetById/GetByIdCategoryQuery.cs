using SalesSystem.Categories.Domain.Dto;

namespace SalesSystem.Categories.Aplication.GetById
{
    public record GetByIdCategoryQuery(Guid Id) : IRequest<ErrorOr<CategoryResponseDto>>;
}
