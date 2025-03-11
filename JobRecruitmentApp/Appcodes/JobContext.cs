using JobRecruitmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobRecruitmentApp.Appcodes
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Description> Descriptions { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    Console.WriteLine("Fluent API đang chạy..."); // Kiểm tra xem hàm có chạy không

        //    modelBuilder.Entity<Job>()
        //        .Property(j => j.Title)
        //        .HasColumnName("Job_Title"); // Đổi tên cột Title -> Job_Title

        //    modelBuilder.Entity<Job>()
        //        .Property(j => j.Company)
        //        .HasColumnName("Company_Name"); // Đổi tên cột Company -> Company_Name
        //}
    }
}
    