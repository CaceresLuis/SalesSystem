namespace SalesSystem.Modules.Products.Domain.DomainErrors
{
    public class ErrorsProduct
    {
        public static Error NotFoundProduct => Error.NotFound("Product", "Produt don't exist.");
    }
}
