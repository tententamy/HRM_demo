using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.GetUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>, IQuery
    {
        public GetAllUsersQuery()
        {

        }

    }
}
