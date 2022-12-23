using Ardalis.Result;
using MediatR;

namespace Tracker.Domain.Entities.RequestModels.Tasks;

public class DeleteTaskRequestModel : IRequest<Result>
{
    public int Id { get; set; }
}