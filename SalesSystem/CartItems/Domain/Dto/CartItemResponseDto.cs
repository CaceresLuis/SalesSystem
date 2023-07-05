using SalesSystem.Products.Domain.Dto;

namespace SalesSystem.CartItems.Domain.Dto
{
    public record CartItemResponseDto
    (
        Guid Id,
        Guid CartId,
        ProductResponseDto Product,
        int Qty
    );
}