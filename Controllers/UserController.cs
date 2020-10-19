using System.Net;
using System.Threading.Tasks;
using ClearSky.Data;
using ClearSky.Entities;
using ClearSky.Entities.DTOs;
using ClearSky.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClearSky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly UserManager<AccountHolder> _userManager;
        private readonly SignInManager<AccountHolder> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ICurrentUser _currentUser;
        public UserController(UserManager<AccountHolder> userManager, SignInManager<AccountHolder> signInManager, ITokenService tokenService,ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        [HttpPost("login")]
        public async Task<ActionResult<AccountUserDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new System.NotImplementedException("User Cannot Be Found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded)
            {
                throw new System.NotImplementedException("Issue Logging In");
            }

            return new AccountUserDTO
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        [HttpPost("register")]
        public async Task<ActionResult<AccountUserDTO>> Register([FromBody] RegisterDTO registerDTO)
        {
            var user = new AccountHolder
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                throw new System.NotImplementedException("Issue Logging In");
            }

            return new AccountUserDTO
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        [HttpGet]
        public AccountUserDTO GetCurrentUserLoggedIn()
        {
            var user = _currentUser.GetCurrentAccountHolder();
        
            return new AccountUserDTO{
                UserName = user.Result.UserName,
                Email = user.Result.Email,
                Token = ""
            };
        }




    }
}