using BooksApiExample.DTOs;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace BooksApiExample.Mapping
{
    public class AuthonticationMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequestDto, IdentityUser>()
            .Map(dest => dest.UserName, src => src.Username)
            .TwoWays();
        }
    }
}
