using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.Buys.Domain.Dto
{
    public record BuyResponseDto
    (
        Guid Id,
        Guid ProductId,
        string Name,
        string Description,
        decimal Price,
        List<ProductCategoryResponseDto> Categorias,
        DateTime DateBuy,
        decimal TotalPay,
        int Qty
    );
}
