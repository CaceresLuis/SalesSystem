using SalesSystem.Modules.Categories.Domain.Dto;

namespace SalesSystem.Modules.Categories.Aplication.GetById
{
    public record GetByIdCategoryQuery(Guid Id) : IRequest<ErrorOr<CategoryResponseDto>>;
}
