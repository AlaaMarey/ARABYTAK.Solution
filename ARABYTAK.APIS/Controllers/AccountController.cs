using Arabytak.Core.Entities.Identity;
using Arabytak.Core.Service.Contract;
using ARABYTAK.APIS.DTOs;
using ARABYTAK.APIS.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _auth;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IAuthService auth)
        {
            _userManager = userManager;
            _signInManager = signInManager;
           _auth = auth;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(loginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) return Unauthorized(new ApiResponse(401,"Email Not Found"));
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401,"Password Not Correct"));
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _auth.CreateTokenAsync(user, _userManager)
            }
                );
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
           // if (!ModelState.IsValid) return BadRequest(ModelState);

           // var existingUser = await _userManager.FindByNameAsync(register.UserName);
         //   if (existingUser != null) return BadRequest(new { Message = "اسم المستخدم موجود بالفعل" });

            var user = new AppUser()
            {
                DisplayName = $"{register.FirstName} {register.LastName}",
                Email = register.Email,
                UserName = register.UserName,
                PhoneNumber = register.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded is false) return BadRequest(new ApiResponse(400));
            //if (!result.Succeeded)
            //{
            //    var errors = result.Errors.Select(e => e.Description).ToList();
            //    return BadRequest(new { StatusCode = 400, Errors = errors });
            //}

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _auth.CreateTokenAsync(user,_userManager)
            });
        }
    }
}
