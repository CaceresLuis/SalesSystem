using SalesSystem.Modules.Images.Domain;

namespace SalesSystem.Modules.Products.Domain.Dto
{
    public record ProductResponseDto
    (
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        DateTime CreateAt,
        DateTime UpdateAt,
        DateTime DeleteAt,
        bool IsUpdated,
        bool IsDeleted,
        List<ImageResponse> Images,
        List<ProductCategoryResponseDto> Categorias
    );
}
