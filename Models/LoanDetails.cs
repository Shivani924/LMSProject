using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProject.Models
{
    public class LoanDetails
    {
        [Key]
        public int LoanId { get; set; }

        public float Amount { get; set; }

        public DateTime DateTime { get; set; }

        public string LoanType { get; set; }

        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public Login? login { get; set; }




    }
}
