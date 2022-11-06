using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProject.Models
{
    public class Documents
    {
        [Key]
        public string UserName { get; set; }
        public int AadharNo { get; set; }
        public int PanNo { get; set; }
        public int DL_No { get; set; }
        [ForeignKey("UserName")]
        public Login? login { get; set; }


    }
}
