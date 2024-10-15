using Microsoft.AspNetCore.Mvc;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Services;
using ClinicNetCore.Settings;
using Microsoft.AspNetCore.Authorization;

namespace ClinicNetCore.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoleController: ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("get-role")]
        public IActionResult GetRole()
        {
            return Ok(_roleService.GetAllRole());
        }
        
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(RoleRequest request)
        {
            return Ok(await _roleService.Create(request));
        }

        [HttpPost("add-claim/{id}")]
        public async Task<IActionResult> AddClaim(Guid id, [FromBody] RequestUpdateRoleUI request)
        {
            return Ok(await _roleService.UpdateRoleAdminWithUIPermission(id, request));
        }


        [HttpGet("all-claim")]
        public IActionResult GetAllClaimI()
        {
            return Ok(SystemClaim.claims);
        }
        [HttpPost("edit-role")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request)
        {
            return Ok(await _roleService.EditRole(request));
        }

        [HttpDelete("delete-role/{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            return Ok(await _roleService.DeleteRole(id));
        }

        [HttpPost("FindClaimByRoleId")]
        public async Task<IActionResult> FindClaimByRoleId([FromBody] FindClaimByRoleIdRequest request)
        {
            return Ok(await _roleService.FindClaimByRoleId(request));
        }
    }
}