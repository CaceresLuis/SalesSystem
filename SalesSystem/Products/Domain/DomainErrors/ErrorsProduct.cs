namespace SalesSystem.Products.Domain.DomainErrors
{
    public class ErrorsProduct
    {
        public static Error NotFoundProduct => Error.Validation("Product", "Produt don't exist.");
    }
}
