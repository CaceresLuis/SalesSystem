using SalesSystem.Products.Domain;
using SalesSystem.Products.Domain.Dto;

namespace SalesSystem.Products.Aplication.GetAll
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
                    product.Id.Value,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Stock,
                    product.CreateAt,
                    product.UpdateAt,
                    product.DeleteAt,
                    product.IsUpdated,
                    product.IsUpdated,
                    product.ProductCategories.Select(pc => pc.Category.Name).ToList()
                )).ToList();
        }
    }
}
