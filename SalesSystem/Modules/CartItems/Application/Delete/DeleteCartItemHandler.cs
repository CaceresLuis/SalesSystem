using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.CartItems.Application.Delete
{
    internal class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            if (await _cartItemRepository.CartItemExistAsync(new CartId(request.CartId), new ProductId(request.ProductId)) is not CartItem cartItem)
                return ErrorCartItem.NotFoundCartItem;

            _cartItemRepository.Delete(cartItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
