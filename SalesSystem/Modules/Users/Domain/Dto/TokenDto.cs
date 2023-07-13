namespace SalesSystem.Modules.Users.Domain.Dto
{
    public class TokenDto
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
