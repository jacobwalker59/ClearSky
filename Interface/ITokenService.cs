using ClearSky.Entities;

namespace ClearSky.Interface
{
    public interface ITokenService
    {
        string CreateToken(AccountHolder user);
    }
}