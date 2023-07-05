namespace SalesSystem.Modules.Products.Aplication.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

}
