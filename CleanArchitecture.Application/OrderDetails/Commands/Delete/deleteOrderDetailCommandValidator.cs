using CleanArchitecture.Application.OrderDetails.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Delete
{
    public class deleteOrderDetailCommandValidator: AbstractValidator<DeleteOrderDetailCommand>
    {
        public deleteOrderDetailCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id does not empty")
                .NotNull().WithMessage("Id does not Null");
        }
    }
}
