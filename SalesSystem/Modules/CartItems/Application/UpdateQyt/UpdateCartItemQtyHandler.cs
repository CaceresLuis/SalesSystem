using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.CartItems.Application.UpdateQyt
{
    internal class UpdateCartItemQtyHandler : IRequestHandler<UpdateCartItemQtyCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;

        public UpdateCartItemQtyHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCartItemQtyCommand request, CancellationToken cancellationToken)
        {
            if (await _cartItemRepository.GetByIdAsync(new CartItemId(request.CartItemId)) is not CartItem cartItem)
                return ErrorCartItem.NotFoundCartItem;

            CartItem cartItemUpdate = new
            (
                cartItem.Id,
                cartItem.ProductId,
                cartItem.CartId,
                request.Qty
            );

            _cartItemRepository.Update(cartItemUpdate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
