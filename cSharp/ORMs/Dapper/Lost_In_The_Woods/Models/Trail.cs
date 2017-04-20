using System;
using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models {

    public class Trail : BaseEntity {

        [Required(ErrorMessage="Trail Name is Required")]
        [MinLength(3, ErrorMessage="Trail Name must be 3 characters long")]
        public string trail_name { get; set; }
        
        [Required(ErrorMessage="Description is Required")]
        [MinLength(10, ErrorMessage="Description must be 10 characters long")]
        public string description { get; set; }

        [Required(ErrorMessage="Trail Length is Required")]
        [RangeAttribute(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int trail_length { get; set; }

        [Required(ErrorMessage="Elevation Change is Required")]
        [RangeAttribute(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int elevation_change { get; set; }

        [Required(ErrorMessage="Longitude is Required")]
        public float longitude { get; set; }
        
        [Required(ErrorMessage="Latitude is Required")]
        public float latitude { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}

        