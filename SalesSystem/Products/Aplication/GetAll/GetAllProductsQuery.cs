using SalesSystem.Products.Domain.Dto;

namespace SalesSystem.Products.Aplication.GetAll
{
    public record GetAllProductsQuery() : IRequest<ErrorOr<IReadOnlyList<ProductResponseDto>>>;

}
