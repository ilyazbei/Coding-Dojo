using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Transactions : BaseEntity
    {
        [Key]
        public int TransactionId { get; set; }
        
        public int depWith { get; set; }

        public int UsersUserId { get; set; }
        public Users User { get; set; }


        public Transactions() : base() {
            
        }
    }
}