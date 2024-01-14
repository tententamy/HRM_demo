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
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Authenticator.Login
{
    public class LoginHandler : IRequestHandler<Login, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.User> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByUsernameAndPassword(request.Username, request.Password);

            if (user == null)
                throw new AuthenticationException("Username or Password is not correct");


            return user;
        }
    }
}
