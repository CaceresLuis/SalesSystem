using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Products.Domain.Dto;
using SalesSystem.Modules.CartItems.Domain.Dto;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.CartItems.Application.GetAll
{
    internal class GetAllCartItemHandler : IRequestHandler<GetAllCartItemQuery, ErrorOr<IReadOnlyList<CartItemResponseDto>>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<CartItemResponseDto>>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
        {
            if(await _cartItemRepository.GetAllAsync(new CartId(request.CartId))! is not IEnumerable<CartItem> cartItems)
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
