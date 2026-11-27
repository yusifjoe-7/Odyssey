namespace Odyssey.Domain.Users;

 public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName {get; set;} // unique 
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public Role role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    
}