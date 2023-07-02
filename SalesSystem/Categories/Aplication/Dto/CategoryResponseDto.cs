namespace SalesSystem.Categories.Aplication.Dto
{
    public record CategoryResponseDto
    (
        Guid Id,
        string Name,
        DateTime CreateAt
    );
}
