using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Buys.Domain.Dto;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Products.Domain.Dto;
using SalesSystem.Modules.Buys.Domain.ValueObjects;

namespace SalesSystem.Modules.Buys.Application.GetAll
{
    internal class GetAllBuysHandler : IRequestHandler<GetAllBuysQuery, ErrorOr<IReadOnlyList<BuyResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBuysHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<BuyResponseDto>>> Handle(GetAllBuysQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BuyRepository.GetAllAsync(request.UserId) is not IEnumerable<Buy> buys)
                return ErrorBuy.NotFoundBuys;

            return buys.Select(buy => new BuyResponseDto
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
            )).ToList();
        }
    }
}
