using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Domain.Entities;

namespace Tracker.Infrastructure.Persistance.DbMap;

public class ProjectDbMap : IEntityTypeConfiguration<ProjectDbModel>
{
    public void Configure(EntityTypeBuilder<ProjectDbModel> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").HasDefaultValue("").IsRequired();
        builder.Property(p => p.StartDate).HasColumnType("TIMESTAMP").HasDefaultValueSql("NOW()").IsRequired();
        builder.Property(p => p.CompletionDate).HasColumnType("TIMESTAMP");
        builder.Property(t => t.Priority).HasColumnType("INTEGER").IsRequired();
        builder.Property(t => t.Status).HasConversion<int>().IsRequired(); 
        builder.HasMany<TaskDbModel>(p => p.ProjectTasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);
    }
}