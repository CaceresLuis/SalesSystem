using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.Get
{
    internal class GetUserHandler : IRequestHandler<GetUserQuery, ErrorOr<SingleUserResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<SingleUserResponseDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _unitOfWork.UserRepository.GetByEmail(request.User);

            List<string> roles = await _unitOfWork.UserRepository.RolesByUserAsync(user!);

            if (user == null)
                return ErrorsUser.UserNotFound;

            return new SingleUserResponseDto
            (
                user.Id,
                user.FirstName!,
                user.LastName!,
                user.Email!,
                user.Cart!.Id!.Value,
                user.UserAddres!.Select(u => new UserAddressResponseDto
                (
                    u.Id,
                    u.Department!,
                    u.City!,
                    u.AddressSpecific!
                )).ToList(),
                user.UserCards!.Select(u => new UserCardResponseDto
                (
                    u.Id,
                    u.CardNumber!,
                    u.OwnerCard!
                )).ToList(),
                roles,
                user.CreateAt,
                user.UpdateAt,
                user.DeleteAt,
                user.IsUpdated,
                user.IsDeleted
             );
        }
    }
}
