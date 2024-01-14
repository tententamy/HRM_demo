using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.DeleteVendor
{
    public class DeleteVendorCommandValidator : AbstractValidator<DeleteVendorCommand>
    {

        public DeleteVendorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is Required");
        }
    }
}
