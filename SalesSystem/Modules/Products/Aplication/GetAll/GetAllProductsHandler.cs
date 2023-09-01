using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Products.Domain.Dto;

namespace SalesSystem.Modules.Products.Aplication.GetAll
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<IReadOnlyList<ProductResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<ProductResponseDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetAllAsync();

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
                product.ProductImages!.Select(pc => new ProductImageResponse
                (
                    pc.Id,
                    pc.ImageUrl!,
                    pc.ProductId!.Value
                )).ToList(),
                product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                (
                    pc.Category!.Id!.Value,
                    pc.Category.Name
                )).ToList()
            )).ToList();
        }
    }
}
