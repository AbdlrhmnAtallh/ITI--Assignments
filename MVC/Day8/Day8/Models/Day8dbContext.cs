using Microsoft.EntityFrameworkCore;
namespace Day8.Models
{
    public class Day8dbContext:DbContext
    {
        public Day8dbContext() { }
        public Day8dbContext(DbContextOptions<Day8dbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }       
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                    Initial Catalog=Day8;
                    Integrated Security=SSPI;
                    TrustServerCertificate=True;"
            );
        }
    }
}
