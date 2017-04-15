using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage="First Name is Required")]
        [MinLength(3, ErrorMessage="First Name must be 3 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        public string First_Name { get; set; }
        
        [Required(ErrorMessage="Last Name is Required")]
        [MinLength(3, ErrorMessage="Last Name must be 3 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        public string Last_Name { get; set; }
 
        [Required(ErrorMessage="Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters long")]
        public string Password { get; set; }

        // [Required(ErrorMessage="Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password and confirmation must match.")]
        public string Confirm_Password { get; set; }
        
        [Required(ErrorMessage="Email is Required")]
        [RegularExpression(@"[\w+\-.]+@[a-z\d\-]+(\.[a-z\d\-]+)*\.[a-z]+", ErrorMessage = "Incorrect Email format")]
        public string Email { get; set; }
    }
}