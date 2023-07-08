namespace SalesSystem.Modules.ProductCategories.Domain.DomainErrors
{
    public static class ErrorProductCategory
    {
        public static Error NotFoundProductCategoryRelation => Error.NotFound("ProductCategory.NotFound", "The relationship between this product and this category does not exist");
    }
}
