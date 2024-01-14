using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Users
{
    public class UserDto : IMapFrom<Domain.Entities.User>
    {
        public UserDto()
        {
            
        }

        public static UserDto Create(Guid Id, string FirstName, string LastName, string PhoneNumber, string Email)
        {
            return new UserDto
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserDto>();
        }
    }
}
