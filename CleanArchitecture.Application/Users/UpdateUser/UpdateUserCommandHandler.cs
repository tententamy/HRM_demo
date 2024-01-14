using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userRepo = await _userRepository.FindByIdAsync(request.Id);

            if (userRepo == null)
            {
                throw new NotFoundException($"Could not find User with Id '{request.Id}'");
            }

            userRepo.FirstName = request.FirstName;
            userRepo.LastName = request.LastName;
            userRepo.Email = request.Email;
            userRepo.PhoneNumber = request.PhoneNumber;

            _userRepository.Update(userRepo);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return userRepo.MapToUserDto(_mapper);
        }


    }
}
