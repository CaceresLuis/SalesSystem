using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Roles.Application.Create
{
    internal class CreateRoleHandler : IRequestHandler<CreateRoleCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.RoleRepository.AddRoleAsync(request.RoleName);

            return Unit.Value;
        }
    }
}