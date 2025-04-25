using AutoMapper;
using BooksService.Api.Responses;
using BooksService.Application.DTO;

namespace BooksService.Api.Mapper.Profiles
{
    internal class UserCreatedProfile: Profile
    {
        public UserCreatedProfile()
        {
            CreateMap<UserDTO, UserCreatedResponse>();
        }
    }
}
