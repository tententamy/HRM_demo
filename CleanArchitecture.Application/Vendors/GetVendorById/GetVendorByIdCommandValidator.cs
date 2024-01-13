using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.GetVendorById
{
    public class GetVendorCommandValidator : AbstractValidator<GetVendorCommand>
    {
        public GetVendorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is not empty");
        }

    }
}
