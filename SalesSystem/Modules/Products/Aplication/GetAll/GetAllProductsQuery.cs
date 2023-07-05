using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.Products.Aplication.GetAll
{
    public record GetAllProductsQuery() : IRequest<ErrorOr<IReadOnlyList<ProductResponseDto>>>;

}
