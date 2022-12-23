using Tracker.Domain.Enums;

namespace Tracker.Domain.Entities.RequestModels.Tasks;

public class EditTaskRequestModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TasksStatus Status { get; set; }
    public int Priority { get; set; }
}