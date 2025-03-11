using Arabytak.Core.Entities.Identity;
using ARABYTAK.APIS.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpGet("Index")]
        public ActionResult<IdentityRole> Index()
        => Ok(_roleManager.Roles.ToList());



        [HttpPost("Create")]
        public async Task<ActionResult<RoleDto>> Create(RoleDto roleDto)
        {
            var identityRole = _mapper.Map<IdentityRole>(roleDto);
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
                return Ok("Role Added ");
            return BadRequest();
        }



        [HttpDelete("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role == null) return BadRequest();
            await _roleManager.DeleteAsync(role);
            return Ok("Role Deleted ");
        }


        [HttpPost("Assign")]
        public async Task<ActionResult> AssignRoleToUser([FromBody] UserRoleDto userRoleDto)
        {
            var user = await _userManager.FindByNameAsync(userRoleDto.UserName);
            // var result = await  _userManager.CheckPasswordAsync(user ,userRoleDto.UserPassword);
            if (user is not null)
            {
                var role = await _roleManager.RoleExistsAsync(userRoleDto.RoleName);
                if (role)
                {
                    await _userManager.AddToRoleAsync(user, userRoleDto.RoleName);
                    return Ok("Role Added !");
                }
            }
            return BadRequest();
        }



        [HttpDelete("Remove")]
        public async Task<ActionResult> RemoveRoleFromUser([FromBody] UserRoleDto userRoleDto)
        {
            var user = await _userManager.FindByNameAsync(userRoleDto.UserName);
            if (user != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, userRoleDto.RoleName);
                if (result.Succeeded) return Ok("Role Removed !");
            }
            return BadRequest();
        }




    }
}
