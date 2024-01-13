using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authenticator.Register
{
    public class RegisterHandler : IRequestHandler<Register, Authentication>
    {
        private readonly IUserRepository _userRepository;

        public RegisterHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }


        public async Task<Authentication> Handle(Register request, CancellationToken cancellationToken)
        {
            var userRepo = await _userRepository.FindByUsername(request.Username);

            if (userRepo != null)
            {
                throw new AuthenticationException("User is already exist");
            }

            var user = new Domain.Entities.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var service = new AuthenticationService();

            var authenticator = new Authentication
            {
                Token = service.CreateJwtToken(user),
                Message = "Register Successfully"
            };

            return authenticator;
        }
    }
}
