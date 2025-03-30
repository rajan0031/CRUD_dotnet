namespace MyDotNetApp.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; } // C# 11+ solution
    public required string Email { get; set; } // C# 11+ solution
}
