using Microsoft.AspNetCore.Mvc;
using MyDotNetApp.Models;
using MyDotNetApp.Services;

namespace MyDotNetApp.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult CreateUser(User user)
        {
            var result = _userService.AddUser(user);
            if (!result.success) return new BadRequestObjectResult(new { message = result.message });

            return new OkObjectResult(new { message = result.message, user = result.user });
        }

        public IActionResult GetUsers(int page, int pageSize)
        {
            var result = _userService.GetUsers(page, pageSize);
            if (!result.success) return new NotFoundObjectResult(new { message = result.message });

            return new OkObjectResult(result.data);
        }

        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            if (!result.success) return new NotFoundObjectResult(new { message = result.message });

            return new OkObjectResult(new { message = result.message, user = result.user });
        }

        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var result = _userService.UpdateUser(id, updatedUser);
            if (!result.success) return new NotFoundObjectResult(new { message = result.message });

            return new OkObjectResult(new { message = result.message, user = result.user });
        }

        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (!result.success) return new NotFoundObjectResult(new { message = result.message });

            return new OkObjectResult(new { message = result.message });
        }
    }
}
