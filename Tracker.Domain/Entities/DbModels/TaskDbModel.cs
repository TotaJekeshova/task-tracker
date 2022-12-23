using Tracker.Domain.Enums;

namespace Tracker.Domain.Entities.DbModels;

public class TaskDbModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TasksStatus Status { get; set; }
    public int Priority { get; set; }
    
    public int ProjectId { get; set; }
    public ProjectDbModel Project { get; set; }
}