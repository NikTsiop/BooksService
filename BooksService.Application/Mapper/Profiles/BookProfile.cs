using AutoMapper;
using BooksService.Application.DTO;
using BooksService.Domain.Entities;

namespace BooksService.Application.Mapper.Profiles
{
    internal class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
