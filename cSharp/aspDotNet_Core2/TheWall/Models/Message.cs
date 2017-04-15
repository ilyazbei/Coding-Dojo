using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Message : BaseEntity
    {
        [Required]
        public string message { get; set; }

        
    }
}