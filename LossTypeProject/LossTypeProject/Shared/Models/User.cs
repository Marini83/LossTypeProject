using System.ComponentModel.DataAnnotations;

namespace LossTypeProject.Server.Models
{
    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string DisplayName { get; set; } = null!;

        [Required]
        public Boolean Active { get; set; } 
    }
}
