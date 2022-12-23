using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class RemoveTaskRequestModel : IRequest<Result>
{
    public int ProjectId { get; set; }
    public int TaskId { get; set; }
}