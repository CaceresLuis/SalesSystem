namespace SalesSystem.Products.Aplication.Create
{
    public record CreateProductCommand
        (
            string Name,
            string Description,
            decimal Price,
            int Stock
        ) : IRequest<ErrorOr<Unit>>;
}
