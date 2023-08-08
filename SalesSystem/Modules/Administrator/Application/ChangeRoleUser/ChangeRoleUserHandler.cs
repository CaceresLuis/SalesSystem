using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Administrator.Application.ChangeRoleUser
{
    internal class ChangeRoleUserHandler : IRequestHandler<ChangeRoleUserCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeRoleUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ChangeRoleUserCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(request.UserEmail) is not User user)
                return ErrorsUser.UserNotFound;

            if (await _unitOfWork.UserRepository.IsUserInRoleAsync(user, request.Role))
                return ErrorsUser.UserNotFound;

            await _unitOfWork.UserRepository.AddUserToRole(user, request.Role);

            return Unit.Value;
        }
    }
}
