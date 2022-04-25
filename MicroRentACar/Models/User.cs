using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroRentACar.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "{0} is required."), Display(Name = "E-mail"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0} must be min {2} max {1}"), DataType(DataType.EmailAddress, ErrorMessage = "{0} is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required."), Display(Name = "Password"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be min {2} max {1}"), DataType(DataType.Password), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "the password needs one capital one letter and one number at least")]
        public string Password { get; set; }

        [NotMapped, Display(Name = "Repeat Password"), DataType(DataType.Password), Compare("Password", ErrorMessage = "Password and Repeat Password dont match")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "{0} is required."), Display(Name = "Role")]
        public int RoleID { get; set; }


        public Role Role { get; set; } // navigasyon için gerekli

    }
}
