using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProject.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public int Phone_No { get; set; }

        public string City { get; set; }

        public string District { get; set; }
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public Login? login { get; set; }
    }
}
