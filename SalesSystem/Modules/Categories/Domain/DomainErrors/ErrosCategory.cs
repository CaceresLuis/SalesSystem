namespace SalesSystem.Modules.Categories.Domain.DomainErrors
{
    public static class ErrosCategory
    {
        public static Error NotFoundCategory => Error.NotFound("Category", "Category don't exist.");
        public static Error CategoryNameAlreadyExist => Error.Conflict("Category", "Category already exist.");
    }
}
