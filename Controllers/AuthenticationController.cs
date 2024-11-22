using Microsoft.AspNetCore.Mvc;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Services;

namespace ClinicNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IUserService _userService;
     
       

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);
        }
        
        //Admin
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
        {
            var response = await _userService.Registration(request);
            return Ok(response);
        }
        // // [Authorize(Roles ="Admin")]
        // [HttpGet("get-user")]
        // public IActionResult GetUser()
        // {
        //     return Ok(_userService.GetListUser());
        // }
        // [Authorize(Roles ="Admin")]
        // [HttpPost("list-user")]
        // public IActionResult ListUser(ListUserRequest request)
        // {
        //     return Ok(_userService.ListUser(request));
        // }
        // // [Authorize(Roles ="Admin")]
        // [HttpDelete("delete-user/{id}")]
        // public IActionResult DeleteUser(Guid id)
        // {
        //     var isDeleted = _userService.DeleteUser(id);
        //     return Ok(isDeleted);
        // }
        // // [Authorize(Roles ="Admin")]
        // [HttpPost("edit-user")]
        // public async Task<IActionResult> EditUser([FromBody] EditUserRequest request)
        // {
        //    var  editUser = await _userService.EditUser(request);
        //     return Ok(editUser);
        // }
        //
        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return Ok(await _userService.GetUserById(id));
        }
    }
}