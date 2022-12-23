using Ardalis.Result;
using MediatR;
using Tracker.Domain.Entities.DbModels;

namespace Tracker.Domain.Entities.RequestModels.Tasks;

public class FindTaskByIdRequestModel : IRequest<Result<TaskDbModel>>
{
    public int Id { get; set; }
}