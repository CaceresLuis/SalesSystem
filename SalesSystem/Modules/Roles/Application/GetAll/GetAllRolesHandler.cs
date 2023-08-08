using Microsoft.AspNetCore.Identity;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Roles.Application.GetAll
{
    internal class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, ErrorOr<IReadOnlyList<IdentityRole>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRolesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<IdentityRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            List<IdentityRole> roles = await _unitOfWork.RoleRepository.GetRolesAsync();

            return roles;
        }
    }
}
