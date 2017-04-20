using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Weddings : BaseEntity
    {
        [Key]
        public int WeddingId { get; set; }
        
        public string wedderOne { get; set; }

        public string wedderTwo { get; set; }

        public DateTime date { get; set; }

        public string weddingAddress { get; set; }

        // public int UsersUserId { get; set; }
        // public Users User { get; set; }


        public Weddings() : base() {
            
        }
    }
}