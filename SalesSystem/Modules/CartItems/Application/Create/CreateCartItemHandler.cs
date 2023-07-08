using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Carts.Domain.ValueObjects;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.CartItems.Application.Create
{
    internal class CreateCartItemHandler : IRequestHandler<CreateCartItemCommad, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CreateCartItemHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository, IProductRepository productRepository, ICartRepository cartRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCartItemCommad request, CancellationToken cancellationToken)
        {
            if (await _cartRepository.GetByIdAsync(new CartId(request.CartId)) is not Cart cart)
                return ErrosCart.NotFoundCart;

            if (await _productRepository.GetByIdAsync(new ProductId(request.ProductId)) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            if (await _cartItemRepository.CartItemExistAsync(cart.Id!, product.Id!) is CartItem cartItemDb)
            {
                int qyt = cartItemDb.Qty + request.Qty;
                CartItem cartItemUpdate = new
                (
                    cartItemDb.Id,
                    cartItemDb.ProductId,
                    cartItemDb.CartId,
                    qyt
                );

                _cartItemRepository.Update(cartItemUpdate);
            }
            else
            {
                CartItem cartItem = new
                (
                    new CartItemId(Guid.NewGuid()),
                    product.Id,
                    cart.Id,
                    request.Qty
                );

                _cartItemRepository.Add(cartItem);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
