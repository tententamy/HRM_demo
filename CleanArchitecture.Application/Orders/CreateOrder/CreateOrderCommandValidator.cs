using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");

            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");

            RuleFor(x => x.Items.Capacity)
                .GreaterThan(0).WithMessage("List items must be greater than 0");
        }
    }
}
