using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.CartItems.Domain.Dto
{
    public record CartItemResponseDto
    (
        Guid Id,
        Guid CartId,
        ProductResponseDto Product,
        int Qty
    );
}