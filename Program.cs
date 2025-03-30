using Microsoft.EntityFrameworkCore;
using MyDotNetApp.Data;
using MyDotNetApp.Services;
using MyDotNetApp.Controllers; // Include UserRoutes

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// ✅ Register services for Dependency Injection
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserController>(); // Register UserController
builder.Services.AddScoped<UserRoutes>(); // Register UserRoutes

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// ✅ Explicitly map the UserRoutes class
var userRoutes = app.Services.GetRequiredService<UserRoutes>();
app.MapControllers();

app.MapGet("/home", () => "hello Rajan!");

app.Run();
