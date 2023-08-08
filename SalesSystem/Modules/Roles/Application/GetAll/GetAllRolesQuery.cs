using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Modules.Roles.Application.GetAll
{
    public record GetAllRolesQuery() : IRequest<ErrorOr<IReadOnlyList<IdentityRole>>>;
}
