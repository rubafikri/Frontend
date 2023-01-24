using Microsoft.AspNetCore.Identity;

namespace BooksApiExample.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string Generate(IdentityUser user);

    }
}
