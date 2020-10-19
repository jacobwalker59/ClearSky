using System.Threading.Tasks;
using ClearSky.Entities;
using ClearSky.Interface;
using Microsoft.AspNetCore.Identity;

namespace ClearSky.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly UserManager<AccountHolder> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IUserAccessor _userAccessor;
        public CurrentUserService(UserManager<AccountHolder> userManager, ITokenService tokenService, IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _tokenService = tokenService;
            _userManager = userManager;
        }
        public async Task<AccountHolder> GetCurrentAccountHolder()
        {

            var user =  await _userManager.FindByNameAsync(_userAccessor.GetCurrentUserName());
            return user;
        }
    }
}