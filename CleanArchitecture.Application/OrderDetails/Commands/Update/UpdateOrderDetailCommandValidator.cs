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
                .NotEmpty().WithMessage("Id does not empty");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity does not empty");
            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("UnitPrice does not empty");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price does not empty");
        }
    }
}
