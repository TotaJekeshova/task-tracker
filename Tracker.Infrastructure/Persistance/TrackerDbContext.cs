using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;
using Tracker.Infrastructure.Persistance.DbMap;

namespace Tracker.Infrastructure.Persistance;

public class TrackerDbContext : DbContext
{
    public DbSet<ProjectDbModel> Projects { get; set; }
    public DbSet<TaskDbModel> Tasks { get; set; }
    
    public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TaskDbMap());
        modelBuilder.ApplyConfiguration(new ProjectDbMap());
    }

}

