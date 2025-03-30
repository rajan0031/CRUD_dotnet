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
