using CleanArchitecture.Application.Orders.UpdateOrder;
using FluentValidation;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        ConfigureValidationRules();
    }

    private void ConfigureValidationRules()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
    }
}
