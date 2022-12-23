namespace Tracker.Domain.Entities;

public class TaskDbModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public int Priority { get; set; }
    
    public int ProjectId { get; set; }
    public ProjectDbModel Project { get; set; }
}