using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMSProject.Models
{
    public class Login
    {
        [Key]


        public string Username { get; set; }

        /* this is not usuable code 
         * public string? Password { get; set; }*/

        public byte[]? PasswordHash { get; set; }
        public byte[]? Key { get; set; }
        public string Role { get; set; }

        [DefaultValue("Active")]
        public string? Status { get; set; }
    }
}
