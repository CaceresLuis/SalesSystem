namespace SalesSystem.Modules.Categories.Domain.DomainErrors
{
    public static class ErrosCategory
    {
        public static Error NotFoundCategory => Error.NotFound("Category.NotFound", "Category don't exist.");
        public static Error CategoryNameAlreadyExist => Error.Conflict("Category.Conflict", "Category already exist.");
    }
}
