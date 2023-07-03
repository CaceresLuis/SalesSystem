namespace SalesSystem.Categories.Domain.Dto
{
    public record CategoryResponseDto
    (
        Guid Id,
        string Name,
        DateTime CreateAt,
        DateTime UpdateAt,
        DateTime DeleteAt,
        bool IsUpdated,
        bool IsDeleted
    );
}
