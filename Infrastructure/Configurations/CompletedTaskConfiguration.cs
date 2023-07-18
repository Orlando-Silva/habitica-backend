using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class CompletedTaskConfiguration : IEntityTypeConfiguration<CompletedTask>
    {
        public void Configure(EntityTypeBuilder<CompletedTask> builder)
        {
            builder.ToTable("completed_task");  

            builder.HasKey(t => t.Id);

            builder.Property(t => t.CompletedAt)
                .IsRequired()
                .HasColumnName("completed_at")
                .HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(t => t.Task);
        }
    }
}
