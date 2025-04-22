using AutoMapper;
using BooksService.Application.Commnands;
using BooksService.Domain.Entities;

namespace BooksService.Application.Mapper.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
