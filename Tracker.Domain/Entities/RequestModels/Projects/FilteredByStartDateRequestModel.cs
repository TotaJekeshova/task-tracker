using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class FilteredByStartDateRequestModel : IRequest<Result<List<ProjectDbModel>>>
{
    public DateTime StartDate { get; set; }
}