using Microsoft.AspNetCore.Http;

namespace SalesSystem.Modules.Products.Aplication.Update
{
    public record UpdateProductCommand
        (
            Guid Id,
            string Name,
            string Description,
            decimal Price,
            int Stock,
            IFormFile File
        ) : IRequest<ErrorOr<Unit>>;

}
