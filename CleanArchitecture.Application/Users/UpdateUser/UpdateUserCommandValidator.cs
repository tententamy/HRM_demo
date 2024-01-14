using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {

        public UpdateUserCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Please enter a valid email address");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required")
                .Length(10).WithMessage("Phone number must have exactly 10 digits.")
                .Matches("^[0-9]*$").WithMessage("Phone number can only contain numeric digits.");
        }
    }
}
