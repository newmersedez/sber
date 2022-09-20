using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Persistence
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext() : base()
        { }

        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasktracker.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskEntity>().HasKey(x => x.Id);
        }

        public DbSet<TaskEntity> TaskEntities { get; set; }
    }
}