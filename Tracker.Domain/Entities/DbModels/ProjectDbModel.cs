using System.Text.Json.Serialization;
using Tracker.Domain.Enums;

namespace Tracker.Domain.Entities;

public class ProjectDbModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
    [JsonIgnore] 
    public List<TaskDbModel> ProjectTasks { get; set; }
}