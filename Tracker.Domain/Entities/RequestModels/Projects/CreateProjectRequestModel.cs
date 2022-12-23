namespace Tracker.Domain.Entities.RequestModels.Projects;

public class CreateProjectRequestModel
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public int Priority { get; set; }
}