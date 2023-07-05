using SalesSystem.CartItems.Domain;
using SalesSystem.Carts.Domain;
using SalesSystem.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.CartItems.Application.Create
{
    internal class CreateCartItemHandler : IRequestHandler<CreateCartItemCommad, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CreateCartItemHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCartItemCommad request, CancellationToken cancellationToken)
        {
            //TODO: verificar q el cart existe
            string? cart = "";

            Product? product = await _productRepository.GetByIdAsync(new ProductId(request.ProductId));
            if (product is not null && cart is not null)
            {
                CartItem cartItem = new
                (
                    new CartItemId(Guid.NewGuid()),
                    product.Id,
                    new CartId(Guid.NewGuid()),
                    request.Qty
                );

                _cartItemRepository.Add(cartItem);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
