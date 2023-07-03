namespace SalesSystem.Products.Aplication.Update
{
    public record UpdateProductCommand
        (
            Guid Id,
            string Name,
            string Description,
            decimal Price,
            int Stock
        ) : IRequest<ErrorOr<Unit>>;

}
