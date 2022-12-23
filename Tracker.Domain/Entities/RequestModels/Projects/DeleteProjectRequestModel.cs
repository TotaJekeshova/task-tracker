using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Projects;

public class DeleteProjectRequestModel : IRequest<Result>
{
    public int Id { get; set; }
}