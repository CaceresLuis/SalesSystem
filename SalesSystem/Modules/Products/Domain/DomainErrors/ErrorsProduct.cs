namespace SalesSystem.Modules.Products.Domain.DomainErrors
{
    public class ErrorsProduct
    {
        public static Error NotFoundProduct => Error.NotFound("Product.NotFound", "Produt don't exist.");
    }
}
