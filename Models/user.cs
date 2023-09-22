using System.ComponentModel.DataAnnotations;

namespace Project2p4.Models
{
    public class user
    {
        [Key]
      
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Custlog> CustLogInfos { get; set; } = new List<Custlog>();
    }
}

