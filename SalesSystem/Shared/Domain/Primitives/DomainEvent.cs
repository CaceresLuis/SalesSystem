namespace SalesSystem.Shared.Domain.Primitives
{
    public record DomainEvent(Guid Id) : INotification;
}
