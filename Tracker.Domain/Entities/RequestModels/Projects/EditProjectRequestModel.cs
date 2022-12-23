using Tracker.Domain.Enums;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class EditProjectRequestModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
}