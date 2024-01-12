using FluentValidation;

namespace CleanArchitecture.Application.Orders.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
