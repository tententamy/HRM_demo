using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRepo = await _userRepository.FindByUsernameAndPassword(request.Username, request.Password);

            if (userRepo == null)
            {
                throw new AuthenticationException("Username or Password is not correct");
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
            return user.MapToUserDto(_mapper);
        }


    }
}
