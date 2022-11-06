using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProject.Models
{
    public class LoanDetails
    {
        [Key]
        public int LoanId { get; set; }

        public float Amount { get; set; }

        /* public DateTime DateTime { get; set; }*/

        public string? currentdate { get; set; }

        public string? LoanType { get; set; }

        [DefaultValue("Pending")]
        public string LoanStatus { get; set; }

        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public Login? login { get; set; }




    }
}
