using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Application.GetAll
{
    internal class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<IReadOnlyList<UserResponseDto>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<UserResponseDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> Users = await _userRepository.GetAll();

            return Users.Select(user => new UserResponseDto
            (
                user.Id,
                user.FirstName!,
                user.LastName!,
                user.Email!,
                user.Cart!.Id!.Value,
                user.UserAddres!.Select(u => new UserAddressResponseDto
                (
                    u.Department!,
                    u.City!,
                    u.AddressSpecific!
                )).ToList(),
                user.CreateAt,
                user.UpdateAt,
                user.DeleteAt,
                user.IsUpdated,
                user.IsDeleted
            )).ToList();
        }
    }
}
