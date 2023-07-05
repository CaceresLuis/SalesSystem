using SalesSystem.CartItems.Domain;
using SalesSystem.Products.Domain.Dto;
using SalesSystem.CartItems.Domain.Dto;
using SalesSystem.Products.Domain.DomainErrors;

namespace SalesSystem.CartItems.Application.GetById
{
    internal class GetByIdCartItemHandler : IRequestHandler<GetByIdCartItemQuery, ErrorOr<CartItemResponseDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetByIdCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<ErrorOr<CartItemResponseDto>> Handle(GetByIdCartItemQuery request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _cartItemRepository.GetByIdAsync(new CartItemId(request.Id));

            if (cartItem is null)
                return ErrorsProduct.NotFoundProduct;

            return new CartItemResponseDto
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
                );
        }
    }
}
