using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class AddTaskRequestModel : IRequest<Result<ProjectDbModel>>
{
    public int ProjectId { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public int TaskPriority { get; set; }
}