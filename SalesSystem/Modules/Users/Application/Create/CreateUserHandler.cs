using SalesSystem.Modules.Categories.Domain.DomainErrors;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Users.Application.Create
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new
            (
                Guid.NewGuid(),
                request.Email,
                request.FistName,
                request.LastName,
                request.PhoneNumber,
                DateTime.UtcNow,
                DateTime.MinValue,
                DateTime.MinValue,
                false,
                false
            );

            await _userRepository.AddAsync(user, request.Password);

            return Unit.Value;
        }
    }
}
