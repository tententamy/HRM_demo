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

namespace CleanArchitecture.Application.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userRepo = await _userRepository.FindByIdAsync(request.Id);

            if (userRepo == null)
            {
                throw new NotFoundException("User not found for deletion.");
            }

            _userRepository.Remove(userRepo);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return userRepo.MapToUserDto(_mapper);
        }


    }
}
