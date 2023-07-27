namespace SalesSystem.Modules.Users.Application.UpdateUserAddress
{
    public record UpdateUserAddressCommand(Guid Id, string UserEmail, string? Department, string? City, string? AddressSpecific) : IRequest<ErrorOr<Unit>>;
}