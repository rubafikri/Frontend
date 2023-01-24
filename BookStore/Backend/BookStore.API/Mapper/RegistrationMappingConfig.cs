﻿using BookStore.API.DTOs;
using BookStore.API.Models;
using Mapster;

namespace BookStore.API.Mapper
{
    public class RegistrationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequestDto, AppUser>()
                .Map(dest => dest.UserName, src => src.Email);

        }
    }
}
