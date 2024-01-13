using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.CreateVendor
{
    public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
    {
        private readonly IVendorRepository _repository;
        public CreateVendorCommandValidator(IVendorRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.phoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Length(10).WithMessage("Phone number must have exactly 10 digits.")
                .Matches("^[0-9]*$").WithMessage("Phone number can only contain numeric digits.");

            RuleFor(x => x.name)
                .MinimumLength(15)
                .MaximumLength(25)
                .WithMessage("The name must around 15 to 25 characters.");

        }
    }
}
