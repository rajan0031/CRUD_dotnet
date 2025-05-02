using MyDotNetApp.Data;
using MyDotNetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyDotNetApp.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Create User
        public (bool success, string message, User? user) AddUser(User user)
        {
            if (user == null) return (false, "Invalid user data!", null);

            _context.Users.Add(user);
            _context.SaveChanges();

            return (true, "User added successfully!", user);
        }

        // ✅ Get all users with pagination
        public (bool success, string message, object? data) GetUsers(int page, int pageSize)
        {
            var totalUsers = _context.Users.Count();
            var users = _context.Users
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            if (!users.Any()) return (false, "No users found!", null);

            return (true, "Users retrieved successfully!", new
            {
                totalUsers,
                page,
                pageSize,
                users
            });
        }

        // ✅ Get user by ID
        public (bool success, string message, User? user) GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return (false, "User not found!", null);

            return (true, "User found!", user);
        }

        // ✅ Update user details
        public (bool success, string message, User? user) UpdateUser(int id, User updatedUser)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null) return (false, "User not found!", null);

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;

            _context.SaveChanges();
            return (true, "User updated successfully!", existingUser);
        }

        // ✅ Delete user
        public (bool success, string message) DeleteUser(int id)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null) return (false, "User not found!");

            _context.Users.Remove(existingUser);
            _context.SaveChanges();

            return (true, "User deleted successfully!");
        }
    }
}




Student Records Management - GET By Id
Description





Student Records Management - GET By Id

A school is looking to create a web service application using Web API in .NET Framework to manage student records. The application will provide endpoints to retrieve the student information.

Create a Service application using Web API .Net Framework.

 

Functionality  

1. In class  Student.cs the properties are already declared.

2. Below code snippet is already given with values predefined in StudentController,

public static List<Student> StudentRecords = new List<Student>()

  Id

  FirstName

  LastName

  GPA

  101

  John

  Doe

   3.6

  102

 Jane

  Smith

   3.9

  103

  Robert

  Johnson

  3.5

  104

  Emily

  Brown

   4.0

  105

  Michael

  Lee

   3.8

 
3. Create a GET method with attribute routing "~/api/get-student/{id}" that returns the student record as a student object.

The GetStudentById method retrieves the student detail from the StudentRecords and return the detail as an object. The ID should be passed as a parameter marked as [FromUri].
