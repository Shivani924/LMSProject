using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProject.Models
{
    public class UserLoan
    {
        [Key]
        public int Id { get; set; }

        public int LoanNo { get; set; }

        public string? LoanStatus { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDetails? userDetails { get; set; }

        public int LoanDetails_Id { get; set; }

        [ForeignKey("LoanDetails_Id")]

        public LoanDetails? loanDetails { get; set; }
    }
}
