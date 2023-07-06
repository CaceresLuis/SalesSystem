using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Users.Domain
{
    public sealed class UserCard : AggregrateRoot
    {
        private UserCard() { }

        public Guid Id { get; private set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public string? CardNumber { get; private set; }
        public string? OwnerCard { get; private set; }
        public string? ExpiredDate { get; private set; }
        public string? CVC { get; private set; }

        public UserCard(Guid id, string userId, string? cardNumber, string? ownerCard, string? expiredDate, string? cvc)
        {
            Id = id;
            UserId = userId;
            CardNumber = cardNumber;
            OwnerCard = ownerCard;
            ExpiredDate = expiredDate;
            CVC = cvc;
        }
    }
}