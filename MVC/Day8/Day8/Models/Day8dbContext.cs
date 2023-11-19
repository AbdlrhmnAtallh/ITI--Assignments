using Microsoft.EntityFrameworkCore;
namespace Day8.Models
{
    public class Day8dbContext:DbContext
    {
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
