using Microsoft.AspNetCore.Mvc;
using MyDotNetApp.Data;
using MyDotNetApp.Models;

namespace MyDotNetApp.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Route for creating a new user
        [HttpPost("api/users/create")]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null) return BadRequest(new { message = "Invalid user data!" });

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "User added successfully!", user });
        }

        // ✅ Route for fetching all users with pagination
        [HttpGet("api/users/list")]
        public IActionResult GetUsers(int page = 1, int pageSize = 10)
        {
            try
            {
                var totalUsers = _context.Users.Count();
                var users = _context.Users
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

                if (!users.Any()) return NotFound(new { message = "No users found!" });

                return Ok(new
                {
                    totalUsers,
                    page,
                    pageSize,
                    users
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred!", error = ex.Message });
            }
        }


        // edit the details of the user by user id 

       [HttpPut("api/users/update/{Id}")] // ✅ Using "Id" (uppercase)
public IActionResult UpdateUser(int Id, [FromBody] User updatedUser) // ✅ Using "Id" (uppercase)
{
    Console.WriteLine($"UpdateUser called with ID: {Id}");

    if (updatedUser == null) 
        return BadRequest(new { message = "Invalid user data!" });

    var existingUser = _context.Users.Find(Id); // ✅ Now using "Id" (uppercase)
    if (existingUser == null) 
        return NotFound(new { message = "User not found!" });

    // Update user details
    existingUser.Name = updatedUser.Name;
    existingUser.Email = updatedUser.Email;

    _context.SaveChanges();

    return Ok(new { message = "User updated successfully!", existingUser });
}


//  ##############// delete a user from the database 

[HttpDelete("api/users/delete/{Id}")] // ✅ Route for deleting user
public IActionResult DeleteUser(int Id) // ✅ Using "Id" (uppercase)
{
    Console.WriteLine($"DeleteUser called with ID: {Id}");

    var existingUser = _context.Users.Find(Id);
    if (existingUser == null) 
        return NotFound(new { message = "User not found!" });

    _context.Users.Remove(existingUser);
    _context.SaveChanges();

    return Ok(new { message = "User deleted successfully!" });
}


// get all users 
  [HttpGet("api/users/getuserdetails/{Id}")]
       public IActionResult GetAllUsers(int? Id, int page = 1, int pageSize = 10)
{
    try
    {
        if (Id.HasValue) // ✅ If Id is provided, return a single user
        {
            var user = _context.Users.Find(Id.Value);
            if (user == null) return NotFound(new { message = "User not found!" });

            return Ok(new { message = "User found!", user });
        }

        // ✅ If no Id is provided, return paginated users
        var totalUsers = _context.Users.Count();
        var users = _context.Users
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

        if (!users.Any()) return NotFound(new { message = "No users found!" });

        return Ok(new
        {
            totalUsers,
            page,
            pageSize,
            users
        });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = "An error occurred!", error = ex.Message });
    }
}

    }
}
