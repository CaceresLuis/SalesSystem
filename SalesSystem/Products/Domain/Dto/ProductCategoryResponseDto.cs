using SalesSystem.Categories.Domain;

namespace SalesSystem.Products.Domain.Dto
{
    public record ProductCategoryResponseDto
    (
        Guid CategoryId,
        string Name
    );
}
