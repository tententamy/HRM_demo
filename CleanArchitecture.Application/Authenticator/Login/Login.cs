using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authenticator.Login
{
    public class Login : IRequest<Authentication>, IQuery
    {
        public Login(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
