using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Users : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }


        public Users() : base() {
            
        }
    }
}