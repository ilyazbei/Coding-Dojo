using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Comment : BaseEntity
    {
        [Required]
        public string comment { get; set; }

        
    }
}