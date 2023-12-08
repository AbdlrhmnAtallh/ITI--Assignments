using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day9.Models
{
    public class Day9DbContext : IdentityDbContext
    {
        public Day9DbContext() { }
        public Day9DbContext(DbContextOptions<Day9DbContext> options)  { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                    Initial Catalog=Day9;
                    Integrated Security=SSPI;
                    TrustServerCertificate=True;"
            );
        }
    }
}

