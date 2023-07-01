using ErrorOr;
using MediatR;

namespace SalesSystem.Categories.Aplication.Create
{
    public record CreateCategoryCommand(string Name) : IRequest<ErrorOr<Unit>>;
}
