using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users
{
    public static class UserDtoMappingExstension
    {

        public static UserDto MapToUserDto(this Domain.Entities.User user, IMapper mapper)
        => mapper.Map<UserDto>(user);

        public static List<UserDto> MapToUserDtoList(this IEnumerable<Domain.Entities.User> users, IMapper mapper)
        => users.Select(x => x.MapToUserDto(mapper)).ToList();
    }
}
