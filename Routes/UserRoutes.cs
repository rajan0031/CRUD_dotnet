using Microsoft.AspNetCore.Mvc;
using MyDotNetApp.Models;
using MyDotNetApp.Services;

namespace MyDotNetApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserRoutes : ControllerBase
    {
        private readonly UserController _userController;

        public UserRoutes(UserService userService)
        {
            _userController = new UserController(userService);
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] User user) => _userController.CreateUser(user);

        [HttpGet("list")]
        public IActionResult GetUsers(int page = 1, int pageSize = 10) => _userController.GetUsers(page, pageSize);

        [HttpGet("getuserdetails/{id}")]
        public IActionResult GetUserById(int id) => _userController.GetUserById(id);

        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser) => _userController.UpdateUser(id, updatedUser);

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id) => _userController.DeleteUser(id);
    }
}
