using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class FindProjectByIdRequestModel : IRequest<Result<ProjectDbModel>>
{
    public int Id { get; set; }
}