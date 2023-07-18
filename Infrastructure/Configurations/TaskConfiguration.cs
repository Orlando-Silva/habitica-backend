using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Enums.TaskStatus;


namespace Infrastructure.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("task");  

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at")
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasDefaultValue(TaskStatus.Active);
        }
    }
}
