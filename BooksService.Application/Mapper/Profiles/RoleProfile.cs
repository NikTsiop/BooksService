using AutoMapper;
using BooksService.Application.DTO;
using BooksService.Domain.Entities;

namespace BooksService.Application.Mapper.Profiles
{
    internal class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>();
        }
    }
}
