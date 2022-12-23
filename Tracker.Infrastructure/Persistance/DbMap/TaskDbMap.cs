using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;

namespace Tracker.Infrastructure.Persistance.DbMap;

public class TaskDbMap : IEntityTypeConfiguration<TaskDbModel>
{
    public void Configure(EntityTypeBuilder<TaskDbModel> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasColumnType("VARCHAR(100)").HasDefaultValue("").IsRequired();
        builder.Property(t => t.Description).HasColumnType("VARCHAR(500)").HasDefaultValue("").IsRequired();
        builder.Property(t => t.Priority).HasColumnType("INTEGER").IsRequired();
        builder.Property(t => t.Status).HasConversion<int>().IsRequired(); 
        builder.HasOne<ProjectDbModel>(t => t.Project)
            .WithMany(p => p.ProjectTasks)
            .HasForeignKey(t => t.ProjectId);
    }
}