using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.TempCartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.TempCartItems.Application.DeleteTempCartItem
{
    internal class DeleteTempCartItemHandler : IRequestHandler<DeleteTempCartItemCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTempCartItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteTempCartItemCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.TempCartItempRepository.GetSimpleTempCartByIdAsync(request.CartItemId) is not TempCartItem tempCartItem)
                return ErrorTempCartItem.NotFoundCartItem;

            _unitOfWork.TempCartItempRepository.DeleteTempCartItem(tempCartItem);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
