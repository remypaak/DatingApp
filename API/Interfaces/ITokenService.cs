namespace API.Interfaces;
using API.Entities;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
