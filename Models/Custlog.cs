using System.ComponentModel.DataAnnotations;

namespace Project2p4.Models
{
    public class Custlog
    {
        [Key]
   
        public int LogId { get; set; }
        [Required]
        public string CustEmail { get; set; } = null!;

        public string CustName { get; set; } = null!;

        public string LogStatus { get; set; } = null!;

        public int? UserId { get; set; }
        [Required]

        public string Description { get; set; } = null!;

        public virtual user? User { get; set; }
    }
}

