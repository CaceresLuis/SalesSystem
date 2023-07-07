namespace SalesSystem.Modules.Users.Domain.DomainErrors
{
    public static class ErrorsUser
    {
        public static Error PhoneNumberWithBadFormat => Error.Validation("Customer.PhoneNumber", "Phone number has not valid format.");
    }
}
