using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroRentACar.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "{0} is required"), Display(Name = "Role Name"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be min {2} max {1}")]
        public string RoleName { get; set; }
    }
}
