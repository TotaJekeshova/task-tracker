namespace Tracker.Domain.Entities.RequestModels.Tasks;

public class CreateTaskRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    
    public int ProjectId { get; set; }
}