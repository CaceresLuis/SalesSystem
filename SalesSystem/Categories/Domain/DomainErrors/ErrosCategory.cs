namespace SalesSystem.Categories.Domain.DomainErrors
{
    public static class ErrosCategory
    {
        public static Error NotFoundCategory => Error.Validation("Category", "Category don't exist.");
    }
}
