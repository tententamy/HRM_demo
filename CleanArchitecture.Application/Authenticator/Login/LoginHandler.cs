using AutoMapper;
using CleanArchitecture.Application.Users.GetUser;
using CleanArchitecture.Application.Users;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CleanArchitecture.Application.Authenticator.Login
{
    public class LoginHandler : IRequestHandler<Login, Authentication>
    {
        private readonly IUserRepository _userRepository;

        public LoginHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<Authentication> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByUsernameAndPassword(request.Username, request.Password);

            if (user == null)
                throw new AuthenticationException("Username or Password is not correct");

            var service = new AuthenticationService();

            var authenticator = new Authentication
            {
                Token = service.CreateJwtToken(user),
                Message = "Login Successfully"
            };

            return authenticator;
        }
    }
}
