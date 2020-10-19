using System.Threading.Tasks;
using ClearSky.Entities;

namespace ClearSky.Interface
{
    public interface ICurrentUser
    {
         Task<AccountHolder> GetCurrentAccountHolder();
    }
}