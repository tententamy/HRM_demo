
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Querys.FindById
{
    public class GetOrderDetailQueryValidator: AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id does not empty")
                .NotNull().WithMessage("Id does not Null")
                .Must(x => x != Guid.Empty).WithMessage("Id must be a valid GUID");
        }
    }
}
