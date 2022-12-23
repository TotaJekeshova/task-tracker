using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class FilteredByEndDateRequestModel : IRequest<Result<List<ProjectDbModel>>>
{
    public DateTime EndDate { get; set; }
}