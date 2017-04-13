
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(3)]
        public string First_Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Last_Name { get; set; }

        [Required]
        [RangeAttribute(0,100)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}