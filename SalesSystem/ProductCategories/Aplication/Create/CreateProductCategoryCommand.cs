namespace SalesSystem.ProductCategories.Aplication.Create
{
    public record CreateProductCategoryCommand(Guid ProductId, List<Guid> CategoriesId) : IRequest<ErrorOr<Unit>>;
}
