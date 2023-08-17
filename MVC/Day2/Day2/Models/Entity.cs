using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace Day2.Models
{
    public class Entity:DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\\SQL2022;
                                        Initial Catalog=ITI;
                                        Integrated Security=SSPI;
                                        TrustServerCertificate=True;"
            );
        }
    }
}
