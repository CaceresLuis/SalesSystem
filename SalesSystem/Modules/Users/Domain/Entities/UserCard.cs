using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Users.Domain.Entities
{
    public sealed class UserCard : AggregrateRoot
    {
        private UserCard() { }

        public Guid Id { get; private set; }
        public User? User { get; set; }
        public Guid UserId { get; set; }
        public string? CardNumber { get; private set; }
        public string? OwnerCard { get; private set; }
        public string? ExpiredDate { get; private set; }
        public string? CVC { get; private set; }

        public UserCard(Guid id, Guid userId, string? cardNumber, string? ownerCard, string? expiredDate, string? cvc)
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