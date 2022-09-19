using Microsoft.AspNetCore.Mvc;
using UserManager.SpecFlow.Api.Messages.Requests;
using UserManager.SpecFlow.Api.Services.Interfaces;

namespace UserManager.SpecFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            return Ok(new { id = _userService.CreateUser(request) });
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            _userService.UpdateUser(request);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAll());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}