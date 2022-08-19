using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        [Required]
        public string Email { get; set; } = "No Email";

        public string? Password { get; set; }

        [Required]
        public UserRole UserRole { get; set; }
    }

    public enum UserRole
    {
        Developer, ProjectManager, Admin
    }
}
