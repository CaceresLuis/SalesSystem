using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Users.Domain.DomainErrors;
using SalesSystem.Modules.Products.Domain.DomainErrors;
using SalesSystem.Modules.CartItems.Domain.ValueObjects;

namespace SalesSystem.Modules.Buys.Application.Create
{
    internal class CreateBuyHandler : IRequestHandler<CreateBuyCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBuyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(CreateBuyCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CartItemRepository.GetByIdAsync(new CartItemId(request.CartItemId)) is not CartItem item)
                return ErrorCartItem.NotFoundCartItem;

            if (await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId!) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            if (await _unitOfWork.UserCardRepository.Get(request.UserCardId, request.UserId) is null)
                return ErrorsUser.UserCardNotFound;

            if (await _unitOfWork.UserAddressRepository.Get(request.UserAddressId, request.UserId) is null)
                return ErrorsUser.UserAddresNotFound;


            Buy buy = new
            (
                new BuyId(Guid.NewGuid()),
                product.Id,
                request.UserId,
                request.Qti,
                DateTime.UtcNow
            );


            Product UpdateProduct = Product.UpdateProduct
                (
                    product.Id!.Value,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Stock - request.Qti,
                    product.CreateAt,
                    product.UpdateAt,
                    product.DeleteAt,
                    product.IsUpdated,
                    product.IsDeleted
                );

            _unitOfWork.BuyRepository.Add(buy);
            _unitOfWork.CartItemRepository.Delete(item);
            _unitOfWork.ProductRepository.Update(UpdateProduct);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
