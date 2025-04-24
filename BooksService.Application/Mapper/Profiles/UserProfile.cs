using AutoMapper;
using BooksService.Application.Commnands;
using BooksService.Domain.Entities;

namespace BooksService.Application.Mapper.Profiles
{
    internal class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
