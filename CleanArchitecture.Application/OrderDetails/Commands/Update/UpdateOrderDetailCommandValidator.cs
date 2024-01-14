using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Update
{
    public class UpdateOrderDetailCommandValidator: AbstractValidator<UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id does not empty")
                .Must(x => x != Guid.Empty).WithMessage("Id must be a valid GUID"); ;
            RuleFor(x => x.Quantity)
                 .NotEmpty().WithMessage("Quantity cannot be empty")
                 .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("UnitPrice cannot be empty")
                .GreaterThan(0).WithMessage("UnitPrice must be greater than 0");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price cannot be empty")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
