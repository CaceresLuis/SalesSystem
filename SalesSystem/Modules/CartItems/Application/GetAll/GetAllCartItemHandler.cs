using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Products.Domain.Dto;
using SalesSystem.Modules.CartItems.Domain.Dto;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.CartItems.Application.GetAll
{
    internal class GetAllCartItemHandler : IRequestHandler<GetAllCartItemQuery, ErrorOr<IReadOnlyList<CartItemResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCartItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<CartItemResponseDto>>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.CartItemRepository.GetAllAsync(new CartId(request.CartId))! is not IEnumerable<CartItem> cartItems)
                return ErrorsProduct.NotFoundProduct;

            return cartItems.Select(cartItem => new CartItemResponseDto
            (
                cartItem.Id!.Value,
                cartItem.CartId!.Value,
                new ProductResponseDto
                (
                    cartItem.Product!.Id!.Value,
                    cartItem.Product.Name,
                    cartItem.Product.Description,
                    cartItem.Product.Price,
                    cartItem.Product.Stock,
                    cartItem.Product.CreateAt,
                    cartItem.Product.UpdateAt,
                    cartItem.Product.DeleteAt,
                    cartItem.Product.IsUpdated,
                    cartItem.Product.IsDeleted,
                    cartItem.Product.ProductCategories!.Select(pc => new ProductCategoryResponseDto
                    (
                        pc.Category!.Id!.Value,
                        pc.Category.Name)
                    ).ToList()
                ),
                cartItem.Qty
            )).ToList();
        }
    }
}
