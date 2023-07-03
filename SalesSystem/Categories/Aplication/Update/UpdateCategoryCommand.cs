namespace SalesSystem.Categories.Aplication.Update
{
    public record UpdateCategoryCommand(Guid Id, string Name) : IRequest<ErrorOr<Unit>>;
}
