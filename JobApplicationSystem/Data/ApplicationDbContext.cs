using Microsoft.EntityFrameworkCore;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job { Id = 1, Title = "Backend Developer", Company = "Google", Description = "Develop backend services", Location = "USA" },
                new Job { Id = 2, Title = "Frontend Developer", Company = "Facebook", Description = "Develop frontend UI", Location = "UK" },
                new Job { Id = 3, Title = "Data Scientist", Company = "Amazon", Description = "Analyze data", Location = "Canada" }
            );
        }
    }
}
