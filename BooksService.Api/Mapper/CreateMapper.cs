﻿using AutoMapper;
using BooksService.Api.Mapper.Profiles;

namespace BooksService.Api.Mapper
{
    public class CreateMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<PagedResponseProfile>();
                cfg.AddProfile<UserCreatedProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
