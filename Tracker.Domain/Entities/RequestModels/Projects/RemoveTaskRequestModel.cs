namespace Tracker.Domain.Entities.RequestModels.Projects;

public class RemoveTaskRequestModel
{
    public int ProjectId { get; set; }
    public int TaskId { get; set; }
}