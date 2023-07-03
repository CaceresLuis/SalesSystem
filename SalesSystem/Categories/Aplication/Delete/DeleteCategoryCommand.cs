namespace SalesSystem.Categories.Aplication.Delete
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
