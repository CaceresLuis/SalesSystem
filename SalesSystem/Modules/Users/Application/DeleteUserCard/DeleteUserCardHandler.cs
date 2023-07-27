using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.DeleteUserCard
{
    internal class DeleteUserCardHandler : IRequestHandler<DeleteUserCardCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteUserCardCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(request.UserEmail) is not User user)
                return ErrorsUser.UserNotFound;

            if (await _unitOfWork.UserCardRepository.Get(request.Id, user.Id) is not UserCard userCard)
                return ErrorsUser.UserCardNotFound;

            _unitOfWork.UserCardRepository.Delete(userCard);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
