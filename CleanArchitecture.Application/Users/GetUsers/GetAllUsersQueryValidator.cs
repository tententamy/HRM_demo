using CleanArchitecture.Application.Users.GetUsers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.User.Login
{
    public class GetUserByIdQueryValidators : AbstractValidator<GetAllUsersQuery>
    {
        public GetUserByIdQueryValidators()
        {
        }
    }
}
