using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDto>, ICommand
    {
        public UpdateUserCommand(Guid Id, string FirstName, string LastName, string Email, string PhoneNumber)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
