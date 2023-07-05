namespace SalesSystem.ProductCategories.Aplication.Delete
{
    public record DeleteProductCategoryCommand(Guid ProductId, Guid CategoriesId) : IRequest<ErrorOr<Unit>>;
}
