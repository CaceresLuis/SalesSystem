using Microsoft.AspNetCore.Http;

namespace SalesSystem.Modules.Products.Aplication.Create
{
    public record CreateProductCommand
        (
            string Name,
            string Description,
            decimal Price,
            int Stock,
            IFormFile File,
            List<Guid> Categories

        ) : IRequest<ErrorOr<Unit>>;
}
