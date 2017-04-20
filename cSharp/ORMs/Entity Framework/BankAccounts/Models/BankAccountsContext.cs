using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class BankAccountsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankAccountsContext(DbContextOptions<BankAccountsContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}