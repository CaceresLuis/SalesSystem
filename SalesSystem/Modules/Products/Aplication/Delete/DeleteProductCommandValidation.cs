using FluentValidation;

namespace SalesSystem.Modules.Products.Aplication.Delete
{
    public class DeleteProductCommandValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidation()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
