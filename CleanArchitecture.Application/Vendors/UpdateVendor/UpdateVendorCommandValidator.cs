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

            RuleFor(x => x.NameUpdated)
                .MinimumLength(15)
                .MaximumLength(25)
                .WithMessage("The name must around 15 to 25 characters.");

            RuleFor(x => x.phoneNumberUpdated)
                .MinimumLength(10)
                .MaximumLength(11)
                .When(x => x.phoneNumberUpdated != null)
                .WithMessage("PhoneNumber among 10 to 11 numbers.");

            RuleFor(x => x.addressUpdated)
                .MaximumLength(150)
                .When(x => x.addressUpdated != null)
                .WithMessage("The address will lest than 150 characters.");
        }
    }
}
