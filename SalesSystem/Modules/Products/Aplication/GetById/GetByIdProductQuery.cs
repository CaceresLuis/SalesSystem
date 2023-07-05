using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.Products.Aplication.GetById
{
    public record GetByIdProductQuery(Guid Id) : IRequest<ErrorOr<ProductResponseDto>>;
}
