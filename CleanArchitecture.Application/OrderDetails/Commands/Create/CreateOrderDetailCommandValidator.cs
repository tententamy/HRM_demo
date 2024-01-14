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
           .NotEmpty().WithMessage("OrderId cannot be empty")
           .Must(x => x != Guid.Empty).WithMessage("OrderId must be a valid GUID");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty")
                .Must(x => x != Guid.Empty).WithMessage("ProductId must be a valid GUID");

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
