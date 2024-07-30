using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BiharStateHousingBoard.Models
{
    public class LoginViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserRole { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile number is requierd")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Invalid Email address")]
        //[StringLength(10, ErrorMessage = "Mobile number must be atleast 10 characters long", MinimumLength = 10)]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string? UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is requierd")]
        public string? Password { get; set; }
        
    }
}
