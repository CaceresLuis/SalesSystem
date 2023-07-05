namespace SalesSystem.Modules.Categories.Aplication.Delete
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
