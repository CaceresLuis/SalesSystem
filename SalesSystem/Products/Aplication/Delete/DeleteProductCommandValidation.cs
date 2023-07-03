using FluentValidation;

namespace SalesSystem.Products.Aplication.Delete
{
    public class DeleteProductCommandValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidation()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
