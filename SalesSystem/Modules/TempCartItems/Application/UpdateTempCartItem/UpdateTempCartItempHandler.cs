using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.TempCartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.TempCartItems.Application.UpdateTempCartItem
{
    internal class UpdateTempCartItempHandler : IRequestHandler<UpdateTempCartItempCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTempCartItempHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateTempCartItempCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.TempCartItempRepository.GetTempCartByIdAsync(request.CartItemId) is not TempCartItem tempCartItem)
                return ErrorTempCartItem.NotFoundCartItem;

            TempCartItem tempCartItemUpdate = new
            (
                tempCartItem.Id,
                tempCartItem.ProductId,
                tempCartItem.TempUser,
                request.Qty
            );

            _unitOfWork.TempCartItempRepository.UpdateTempCartItem(tempCartItemUpdate);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
