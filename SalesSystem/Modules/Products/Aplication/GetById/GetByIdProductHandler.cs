using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Products.Domain.Dto;
using SalesSystem.Modules.Products.Domain.DomainErrors;
using SalesSystem.Modules.Images.Domain;

namespace SalesSystem.Modules.Products.Aplication.GetById
{
    internal class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, ErrorOr<ProductResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<ProductResponseDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.GetByIdAsync(new ProductId(request.Id)) is not Product product)
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
                product.IsDeleted,
                product.Images!.Select(pc => new ImageResponse
                (
                    pc.Id,
                    pc.ImageUrl
                )).ToList(),
                product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                (
                    pc.Category!.Id!.Value,
                    pc.Category.Name
                )).ToList()
            );
        }
    }
}
