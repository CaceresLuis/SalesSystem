using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Application.GetAll
{
    internal class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<IReadOnlyList<UserResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<UserResponseDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> Users = await _unitOfWork.UserRepository.GetAll();

            return Users.Select(user => new UserResponseDto
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
                user.CreateAt,
                user.UpdateAt,
                user.DeleteAt,
                user.IsUpdated,
                user.IsDeleted
            )).ToList();
        }
    }
}
