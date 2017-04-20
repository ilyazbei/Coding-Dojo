using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Reviews : BaseEntity
    {
        [Key]
        public int idReviews { get; set; }

        [Required(ErrorMessage="Reviever Name is Required")]
        [MinLength(3, ErrorMessage="Reviewer Name must be 3 characters long")]
        public string Reviewer_Name { get; set; }
        
        [Required(ErrorMessage="Restaurant Name is Required")]
        [MinLength(3, ErrorMessage="Restaurant Name must be 3 characters long")]
        public string Restaurant_Name { get; set; }
        
        [Required(ErrorMessage="Review is Required")]
        [MinLength(10, ErrorMessage="Review must be 10 characters long")]
        public string Review { get; set; }
        
        [Required(ErrorMessage="Date of visit is Required")]
        public DateTime? Date_Of_Visit { get; set; }

        [Required(ErrorMessage="Stars are Required")]
        public int? stars { get; set; }

        public Reviews() : base() {
            
        }
    }
}
