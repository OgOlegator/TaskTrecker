using Microsoft.EntityFrameworkCore;
using TaskTrecker.TaskTreckerApi.Models;
using Task = TaskTrecker.TaskTreckerApi.Models.Task;

namespace TaskTrecker.TaskTreckerApi.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Project>()
                .Property(e => e.Priority)
                .HasConversion(
                    v => v.ToString(),
                    v => (SD.Priority)Enum.Parse(typeof(SD.Priority), v));

            modelBuilder
                .Entity<Task>()
                .Property(e => e.Priority)
                .HasConversion(
                    v => v.ToString(),
                    v => (SD.Priority)Enum.Parse(typeof(SD.Priority), v));

            modelBuilder
                .Entity<Project>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (StatusProject)Enum.Parse(typeof(StatusProject), v));

            modelBuilder
                .Entity<Task>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (StatusTask)Enum.Parse(typeof(StatusTask), v));
        }
    }
}
