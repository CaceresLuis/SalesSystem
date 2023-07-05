namespace SalesSystem.Modules.Categories.Aplication.Create
{
    public record CreateCategoryCommand(string Name) : IRequest<ErrorOr<Unit>>;
}
