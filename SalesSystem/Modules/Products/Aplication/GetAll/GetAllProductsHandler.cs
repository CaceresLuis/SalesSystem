using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.Products.Aplication.GetAll
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<IReadOnlyList<ProductResponseDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<ProductResponseDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();

            return products.Select(product => new ProductResponseDto
            (
                product.Id!.Value,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                product.CreateAt,
                product.UpdateAt,
                product.DeleteAt,
                product.IsUpdated,
                product.IsDeleted,
                product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                (
                    pc.Category!.Id!.Value,
                    pc.Category.Name
                )).ToList()
            )).ToList();
        }
    }
}
