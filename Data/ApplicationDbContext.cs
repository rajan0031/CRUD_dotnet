using Microsoft.EntityFrameworkCore;
using MyDotNetApp.Models;  // Replace with your actual namespace

namespace MyDotNetApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
