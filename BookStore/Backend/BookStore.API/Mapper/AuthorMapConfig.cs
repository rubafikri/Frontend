using BookStore.API.DTOs;
using BookStore.API.Models;
using Mapster;

namespace BookStore.API.Mapper
{
    public class AuthorMapConfig: IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateAutherDto, Authors>()
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
