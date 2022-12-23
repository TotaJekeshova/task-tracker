using Ardalis.Result;
using MediatR;
using Tracker.Domain.Entities.DbModels;

namespace Tracker.Domain.Entities.RequestModels.Tasks;

public class CreateTaskRequestModel : IRequest<Result<TaskDbModel>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    
    public int ProjectId { get; set; }
}