using CleanArchitecture.Application.Users.GetUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authenticator.Login
{
    public class GetUserByIdQueryValidator : AbstractValidator<Login>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
