namespace API.Interfaces;
using API.Entities;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}
