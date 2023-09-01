namespace SalesSystem.Modules.Products.Domain.Dto
{
    public record ProductImageResponse
    (
        Guid Id,
        string ImageName,
        Guid ProductId
    );
}
