using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.CartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.CartItems.Application.Delete
{
    internal class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCartItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CartItemRepository.GetByIdAsync(new CartItemId(request.CartItemId)) is not CartItem cartItem)
                return ErrorCartItem.NotFoundCartItem;

            _unitOfWork.CartItemRepository.Delete(cartItem);
            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
