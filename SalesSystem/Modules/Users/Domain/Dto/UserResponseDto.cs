namespace SalesSystem.Modules.Users.Domain.Dto
{
    public record UserResponseDto
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        Guid CartId,
        DateTime CreateAt,
        DateTime UpdateAt,
        DateTime DeleteAt,
        bool IsUpdated,
        bool IsDeleted
    );
}
