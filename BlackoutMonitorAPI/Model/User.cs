using System.ComponentModel.DataAnnotations;

namespace BlackoutMonitorAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        public string Role { get; set; } = "User";
    }
}
