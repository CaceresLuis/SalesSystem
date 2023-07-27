namespace SalesSystem.Modules.Users.Domain.Dto
{
    public record UserAddressResponseDto
    (
        Guid Id,
        string Department,
        string City,
        string AddressSpecific
    );
}
