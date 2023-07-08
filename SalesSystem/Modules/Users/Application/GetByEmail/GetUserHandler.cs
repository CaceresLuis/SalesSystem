using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.GetByEmail
{
    internal class GetUserHandler : IRequestHandler<GetUserQuery, ErrorOr<UserResponseDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ErrorOr<UserResponseDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            User? user = Guid.TryParse(request.User, out Guid email) ? await _userRepository.GetById(email) : await _userRepository.GetByEmail(request.User);


            if (user == null)
                return ErrorsUser.UserNotFound;

            return new UserResponseDto
            (
                user.Id,
                user.FirstName!,
                user.LastName!,
                user.Email!,
                user.Cart!.Id!.Value,
                user.CreateAt,
                user.UpdateAt,
                user.DeleteAt,
                user.IsUpdated,
                user.IsDeleted
             );
        }
    }
}
