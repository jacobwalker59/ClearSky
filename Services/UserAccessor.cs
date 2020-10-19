using System.Security.Claims;
using System.Linq;
using ClearSky.Interface;
using Microsoft.AspNetCore.Http;

namespace ClearSky.Services
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _accessor;
        public UserAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string GetCurrentUserName()
        {
             var username = _accessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
             
            return username;

        }
    }
}