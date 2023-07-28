using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Buys.Domain.Dto;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Products.Domain.Dto;
using SalesSystem.Modules.Buys.Domain.ValueObjects;

namespace SalesSystem.Modules.Buys.Application.GetById
{
    internal class GetByIdBuyHandler : IRequestHandler<GetByIdBuyQuery, ErrorOr<BuyResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdBuyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<BuyResponseDto>> Handle(GetByIdBuyQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BuyRepository.GetByIdAsync(new BuyId(request.BuyId)) is not Buy buy)
                return ErrorBuy.NotFoundBuy;

            return new BuyResponseDto
            (
                buy.Id!.Value,
                buy.Product!.Id!.Value,
                buy.Product.Name,
                buy.Product.Description,
                buy.Product.Price,
                buy.Product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                (
                    pc.Category!.Id!.Value,
                    pc.Category.Name)
                ).ToList(),
                buy.DateBuy,
                buy.Product.Price * buy.Qty,
                buy.Qty
            );
        }
    }
}
