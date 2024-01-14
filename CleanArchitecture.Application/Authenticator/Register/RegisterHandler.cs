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
    public class RegisterHandler : IRequestHandler<Register, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }


        public async Task<Domain.Entities.User> Handle(Register request, CancellationToken cancellationToken)
        {
            var userRepo = await _userRepository.FindByUsername(request.Username);

            if (userRepo != null)
            {
                throw new AuthenticationException("User is already exist");
            }

            var users = await _userRepository.FindAllAsync(cancellationToken);
            var flag = users.Where(x => x.Email == request.Email).FirstOrDefault();

            if (flag != null)
            {
                throw new AuthenticationException("Email is already exist");
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


            return user;
        }
    }
}
