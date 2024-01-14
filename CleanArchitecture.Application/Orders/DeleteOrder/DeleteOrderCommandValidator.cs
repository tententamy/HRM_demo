using CleanArchitecture.Application.Orders.GetOrderById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.DeleteOrder
{

    public class DeleteOrderCommandValidator : AbstractValidator<GetOrderByIdQuery>
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
