namespace SalesSystem.Modules.Users.Domain.DomainErrors
{
    public static class ErrorsUser
    {
        public static Error PhoneNumberWithBadFormat => Error.Conflict("User.PhoneNumber", "Phone number has not valid format.");

        public static Error UserError(string error) => Error.Conflict("User.Conflict", error);
        public static Error UserNotFound => Error.NotFound("User.NotFound", "User don't exist");
    }
}
