namespace SalesSystem.Modules.Users.Domain.Dto
{
    public record UserCardResponseDto
    (
        Guid Id,
        string CardNumber,
        string OwnerCard
    );
}
