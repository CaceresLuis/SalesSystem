namespace SalesSystem.Shared.Domain.ValueObjects
{
    public static class SaveError
    {
        public static Error GenericError => Error.NotFound("SaveCahange.Error", "Something was wrong");
    }
}
