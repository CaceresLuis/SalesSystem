namespace SalesSystem.Modules.Products.Aplication.Create
{
    public record CreateProductCommand
        (
            string Name,
            string Description,
            string ImageUrl,
            decimal Price,
            int Stock,
            List<Guid> Categories
        ) : IRequest<ErrorOr<Unit>>;
}
