using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.ValueObjects;
using SalesSystem.Modules.Products.Domain.DomainErrors;
using SalesSystem.Modules.CartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.CartItems.Application.CreateTempCartItem
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

            if (!string.IsNullOrEmpty(request.CartId))
            {
                if (await _unitOfWork.CartItemRepository.GetTempCartByIdAsync(Guid.Parse(request.CartId)) is not TempCartItem tempCartItem)
                    return ErrorCartItem.NotFoundCartItem;

                int qty = tempCartItem.Qty + request.Qty;
                tempUser = new
                (
                    tempCartItem.Id,
                    tempCartItem.ProductId,
                    tempCartItem.TempUser,
                    qty
                );

                _unitOfWork.CartItemRepository.UpdateTempCartItem(tempUser);
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

                _unitOfWork.CartItemRepository.AddTempCartItem(tempUser);
            }

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return tempUser.Id!.Value.ToString();
        }
    }
}
