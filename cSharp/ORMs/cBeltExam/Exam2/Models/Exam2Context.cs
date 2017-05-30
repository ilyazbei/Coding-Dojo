using Microsoft.EntityFrameworkCore;
 
namespace Exam2.Models
{
    public class Exam2Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Exam2Context(DbContextOptions<Exam2Context> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Connections> Connections { get; set; }
    }
}