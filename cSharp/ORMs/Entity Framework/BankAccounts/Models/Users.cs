using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Users : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public int curBal { get; set; }

        public Users() : base() {
            
        }
    }
}
