using CleanArchitecture.Application.Users.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authenticator.Register
{
    public class RegisterValidator : AbstractValidator<Register>
    {

        public RegisterValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is Required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("First Name is Required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is Required")
                .EmailAddress().WithMessage("Please enter a valid email address");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Length(10).WithMessage("Phone number must have exactly 10 digits.")
                .Matches("^[0-9]*$").WithMessage("Phone number can only contain numeric digits.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is Required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is Required");
        }
    }
}
