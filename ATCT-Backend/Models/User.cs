

// Creating the User class with properties for Id, Name, Email, and Password



namespace ATCT_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<UserSession>? UserSessions { get; set; }
    }
}
