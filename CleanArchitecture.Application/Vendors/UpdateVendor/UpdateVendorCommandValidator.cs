using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.UpdateVendor
{
    public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
    {
        public UpdateVendorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is not null");

            RuleFor(x => x.Name)
                .MinimumLength(5)
                .MaximumLength(25)
                .WithMessage("The name must around 5 to 25 characters.");

            RuleFor(x => x.PhoneNumber)
                .MinimumLength(10)
                .MaximumLength(11)
                .When(x => x.PhoneNumber != null)
                .WithMessage("PhoneNumber among 10 to 11 numbers.");

            RuleFor(x => x.Address)
                .MaximumLength(150)
                .When(x => x.Address != null)
                .WithMessage("The address will lest than 150 characters.");
        }
    }
}
