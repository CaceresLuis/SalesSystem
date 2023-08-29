using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Products.Domain.Dto;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.TempCartItems.Domain.Dto;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.TempCartItems.Application.GetAllTempCartItem
{
    internal class GetAllTempCartItemHandler : IRequestHandler<GetAllTempCartItemQuery, ErrorOr<IReadOnlyList<TempCartItemResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTempCartItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<IReadOnlyList<TempCartItemResponseDto>>> Handle(GetAllTempCartItemQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.TempCartItempRepository.GetAllTempCartAsync(request.TempUser)! is not IEnumerable<TempCartItem> tempCartItems)
                return ErrorsProduct.NotFoundProduct;

            return tempCartItems.Select(tempCartItem => new TempCartItemResponseDto
            (
                tempCartItem.Id!.Value,
                tempCartItem.TempUser,
                new ProductResponseDto
                (
                    tempCartItem.Product!.Id!.Value,
                    tempCartItem.Product.Name,
                    tempCartItem.Product.Description,
                    tempCartItem.Product.Price,
                    tempCartItem.Product.Stock,
                    tempCartItem.Product.CreateAt,
                    tempCartItem.Product.UpdateAt,
                    tempCartItem.Product.DeleteAt,
                    tempCartItem.Product.IsUpdated,
                    tempCartItem.Product.IsDeleted,
                    tempCartItem.Product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                    (
                        pc.Category!.Id!.Value,
                        pc.Category.Name)
                    ).ToList()
                ),
                tempCartItem.Qty,
                tempCartItem.Product.Price * tempCartItem.Qty
            )).ToList();
        }
    }
}