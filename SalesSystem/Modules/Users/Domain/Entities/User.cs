using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Users.Domain.ValueObjetcs;

namespace SalesSystem.Modules.Users.Domain.Entities
{
    public class User : IdentityUser
    {
        private User() { }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public ICollection<UserCard>? UserCards { get; set; }
        public ICollection<UserAddres>? UserAddres { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public Cart? Cart { get; set; }
        public new PhoneNumber? PhoneNumber { get; set; }

        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public DateTime DeleteAt { get; private set; }
        public bool IsUpdated { get; private set; }
        public bool IsDeleted { get; private set; }

        public User(string email, string firstName, string lastName, PhoneNumber phoneNumbre, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdated, bool isDeleted)
        {
            Email = email;
            UserName = email;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumbre;
            CreateAt = createAt;
            UpdateAt = upDateAt;
            DeleteAt = deleteAt;
            IsUpdated = isUpdated;
            IsDeleted = isDeleted;
        }

        //public record UserCreated(string id, string email, string firstName, string lastName, PhoneNumber phoneNumbre, DateTime createAt);

        //public void PersoneRegistered()
        //{
        //    Events.UserCreated.Publish(new UserCreated(Id, Email!, FirstName!, LastName!, PhoneNumber!, CreateAt));
        //}
    }
}