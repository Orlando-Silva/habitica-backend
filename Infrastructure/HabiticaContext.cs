using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure
{
    public class HabiticaContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public DbSet<CompletedTask> CompletedTasks { get; set; }

        public HabiticaContext(DbContextOptions<HabiticaContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new CompletedTaskConfiguration());
        }
    }
}
