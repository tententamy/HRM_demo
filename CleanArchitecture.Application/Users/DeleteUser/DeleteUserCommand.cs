using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<UserDto>, ICommand
    {
        public DeleteUserCommand(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; set; }
    }
}
