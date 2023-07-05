using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.Products.Domain.DomainErrors;
using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.Products.Aplication.GetById
{
    internal class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, ErrorOr<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ErrorOr<ProductResponseDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            if (await _productRepository.GetByIdAsync(new ProductId(request.Id)) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            return new ProductResponseDto
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
                product.IsUpdated,
                product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                (
                    pc.Category!.Id!.Value,
                    pc.Category.Name
                )).ToList()
            );
        }
    }
}
