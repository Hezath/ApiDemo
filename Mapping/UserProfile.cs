using AutoMapper;
using ApiDemo.Models;

namespace ApiDemo.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(); 
            CreateMap<UserDto, User>(); 
        }
    }
}
