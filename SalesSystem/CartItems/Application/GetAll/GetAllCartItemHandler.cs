using SalesSystem.CartItems.Domain;

namespace SalesSystem.CartItems.Application.GetAll
{
    internal class GetAllCartItemHandler : IRequestHandler<GetAllCartItemQuery, ErrorOr<List<CartItem>>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public Task<ErrorOr<List<CartItem>>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
