using CleanArchitecture.Application.Orders.GetOrderById;
using FluentValidation;

namespace CleanArchitecture.Application.Orders.GetByIdOrder
{
    public class GetByIdOrderQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetByIdOrderQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }
}
