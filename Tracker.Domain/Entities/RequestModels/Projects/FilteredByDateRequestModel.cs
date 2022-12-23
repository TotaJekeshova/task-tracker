using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class FilteredByDateRequestModel : IRequest<Result<List<ProjectDbModel>>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}