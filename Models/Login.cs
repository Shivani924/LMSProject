using System.ComponentModel.DataAnnotations;

namespace LMSProject.Models
{
    public class Login
    {
        [Key]
        public string Username { get; set; }

        /*public string? Password { get; set; }*/

        public byte[]? PasswordHash { get; set; }
        public byte[]? Key { get; set; }
        public string Role { get; set; }

        public string Status { get; set; }
    }
}
