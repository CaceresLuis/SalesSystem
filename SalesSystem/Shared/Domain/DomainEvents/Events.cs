using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Shared.Domain.DomainEvents
{
    public static class Events
    {
        public static readonly DomainEvent<User.UserCreated> UserCreated = new();
    }
}
