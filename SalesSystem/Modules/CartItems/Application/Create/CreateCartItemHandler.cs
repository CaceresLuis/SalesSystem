﻿using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Carts.Domain.ValueObjects;
using SalesSystem.Modules.Products.Domain.DomainErrors;
using SalesSystem.Shared.Domain.ValueObjects;

namespace SalesSystem.Modules.CartItems.Application.Create
{
    internal class CreateCartItemHandler : IRequestHandler<CreateCartItemCommad, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCartItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCartItemCommad request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CartRepository.GetByIdAsync(new CartId(request.CartId)) is not Cart cart)
                return ErrosCart.NotFoundCart;

            if (await _unitOfWork.ProductRepository.GetByIdAsync(new ProductId(request.ProductId)) is not Product product)
                return ErrorsProduct.NotFoundProduct;

            if (await _unitOfWork.CartItemRepository.CartItemExistAsync(cart.Id!, product.Id!) is CartItem cartItemDb)
            {
                int qyt = cartItemDb.Qty + request.Qty;
                CartItem cartItemUpdate = new
                (
                    cartItemDb.Id,
                    cartItemDb.ProductId,
                    cartItemDb.CartId,
                    qyt
                );

                _unitOfWork.CartItemRepository.Update(cartItemUpdate);
            }
            else
            {
                CartItem cartItem = new
                (
                    new CartItemId(Guid.NewGuid()),
                    product.Id,
                    cart.Id,
                    request.Qty
                );

                _unitOfWork.CartItemRepository.Add(cartItem);
            }

            if(await _unitOfWork.SaveChangesAsync(cancellationToken) < 1)
                return SaveError.GenericError;

            return Unit.Value;
        }
    }
}
