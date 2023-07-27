using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.CreatUserCard
{
    internal class CreateUserCardHandler : IRequestHandler<CreateUserCardCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUserCardCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(request.UserEmail) is not User user)
                return ErrorsUser.UserNotFound;

            UserCard userCard = new
            (
                Guid.NewGuid(),
                user.Id,
                request.CardNumber,
                request.OwnerCard,
                request.ExpCard,
                request.Cvc
            );

            _unitOfWork.UserCardRepository.Add(userCard);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
