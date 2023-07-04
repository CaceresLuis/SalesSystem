namespace SalesSystem.Products.Aplication.Create
{
    public record CreateProductCommand
        (
            string Name,
            string Description,
            decimal Price,
            int Stock,
            List<Guid> Categories
        ) : IRequest<ErrorOr<Unit>>;
}
