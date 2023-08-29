using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.Products.Domain.DomainErrors;

namespace SalesSystem.Modules.TempCartItems.Application.CreateTempCartItem
{
    internal class CreateTempCartItemHandler : IRequestHandler<CreateTempCartItemCommand, ErrorOr<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTempCartItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<string>> Handle(CreateTempCartItemCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.GetByIdAsync(new ProductId(request.ProductId)) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            TempCartItem tempUser;

            var u = await _unitOfWork.TempCartItempRepository.TempUserExist(request.CartId);

            if (await _unitOfWork.TempCartItempRepository.TempUserExist(request.CartId))
            {
                if (await _unitOfWork.TempCartItempRepository.ExistTempCartItem(request.CartId, new ProductId(request.ProductId)) is TempCartItem tempCartItem)
                {
                    int qty = tempCartItem.Qty + request.Qty;
                    tempUser = new
                    (
                        tempCartItem.Id,
                        tempCartItem.ProductId,
                        tempCartItem.TempUser,
                        qty
                    );
                    _unitOfWork.TempCartItempRepository.UpdateTempCartItem(tempUser);
                }
                else
                {
                    tempUser = new
                    (
                    Guid.NewGuid(),
                    product.Id,
                    request.CartId,
                    request.Qty
                    );
                    _unitOfWork.TempCartItempRepository.AddTempCartItem(tempUser);
                }
            }
            else
            {
                tempUser = new
                    (
                    Guid.NewGuid(),
                    product.Id,
                    Guid.NewGuid(),
                    request.Qty
                    );
                _unitOfWork.TempCartItempRepository.AddTempCartItem(tempUser);
            }

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return tempUser.TempUser.ToString();
        }
    }
}
