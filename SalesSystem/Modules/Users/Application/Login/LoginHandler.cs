using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Domain.DomainErrors;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Application.Login
{
    internal class LoginHandler : IRequestHandler<LoginQuery, ErrorOr<TokenDto>>
    {
        private readonly IGenerateToken _generateToken;
        private readonly IUserRepository _userRepository;

        public LoginHandler(IUserRepository userRepository, IGenerateToken generateToken)
        {
            _generateToken = generateToken ?? throw new ArgumentNullException(nameof(generateToken));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ErrorOr<TokenDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByEmail(request.Email);

            SignInResult login = await _userRepository.LoginAync(request.Email!, request.Password);

            if (!login.Succeeded)
                return ErrorsUser.UserInvalid;


            if (login.IsLockedOut)
                return ErrorsUser.UserBloked;


            TokenDto token = await _generateToken.GetToken(user!);
            return token;
        }
    }
}
