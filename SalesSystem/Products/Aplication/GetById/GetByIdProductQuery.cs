using SalesSystem.Products.Domain.Dto;

namespace SalesSystem.Products.Aplication.GetById
{
    public record GetByIdProductQuery(Guid Id) : IRequest<ErrorOr<ProductResponseDto>>;
}
