using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.TempCartItems.Domain.Dto
{
    public record TempCartItemResponseDto
    (
        Guid Id,
        Guid TempUser,
        ProductResponseDto Product,
        int Qty,
        decimal Total
    );
}
