using AutoMapper;
using BooksService.Api.Responses;
using BooksService.Application.DTO;

namespace BooksService.Api.Mapper.Profiles
{
    public class PagedResponseProfile: Profile
    {
        public PagedResponseProfile()
        {
            CreateMap<PagedResult<BookDTO>, PagedResponse<BookDTO>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}
