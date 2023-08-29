using Microsoft.EntityFrameworkCore;

namespace Day4.Models
{
    public class AppdbContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<FootballClub> FootballClub { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                              Initial Catalog=League;
                              Integrated Security=SSPI;TrustServerCertificate=True;"
            );
        }
    }
}
