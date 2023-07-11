using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.CartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.CartItems.Application.UpdateQyt
{
    internal class UpdateCartItemQtyHandler : IRequestHandler<UpdateCartItemQtyCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCartItemQtyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCartItemQtyCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CartItemRepository.GetByIdAsync(new CartItemId(request.CartItemId)) is not CartItem cartItem)
                return ErrorCartItem.NotFoundCartItem;

            CartItem cartItemUpdate = new
            (
                cartItem.Id,
                cartItem.ProductId,
                cartItem.CartId,
                request.Qty
            );

            _unitOfWork.CartItemRepository.Update(cartItemUpdate);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
