﻿using AutoMapper;
using BooksService.Application.Mapper.Profiles;

namespace BooksService.Application.Mapper
{
    internal class CreateMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<RoleProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
