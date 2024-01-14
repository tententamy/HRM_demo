using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.GetUser
{ 
    public class GetUserByIdQuery : IRequest<UserDto>, IQuery
    {
        public GetUserByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
        public Guid Id { get; set; }
    }
}
