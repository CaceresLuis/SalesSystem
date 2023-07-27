namespace SalesSystem.Modules.Users.Domain.Dto
{
    public record SingleUserResponseDto
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        Guid CartId,
        List<UserAddressResponseDto> UserAddress,
        List<UserCardResponseDto> Cards,
        DateTime CreateAt,
        DateTime UpdateAt,
        DateTime DeleteAt,
        bool IsUpdated,
        bool IsDeleted
    );
}
