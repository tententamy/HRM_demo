using CleanArchitecture.Application.Orders.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Create
{
    public class CreateOrderDetailCommandValidator: AbstractValidator<CreateOrderDetailCommand>
    {
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId does not empty");
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId does not empty");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity does not empty");
            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("UnitPrice does not empty");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price does not empty");
        }
    }
}
