using HardTime.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HardTime.Controllers
{
    [Route ("account/")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            var newUser = new AppUser { Email = userRegisterDto.Email, UserName = userRegisterDto.Email};
            var result = await _userManager.CreateAsync(newUser, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var foundUser = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (foundUser == null)
            {
                return NotFound();
            }
            
            var result = await _signInManager.PasswordSignInAsync(foundUser, userLoginDto.Password, true, false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
