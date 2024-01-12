using FluentValidation;

namespace CleanArchitecture.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }
}
