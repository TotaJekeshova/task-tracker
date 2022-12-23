using Ardalis.Result;
using MediatR;
using Tracker.Domain.Entities.DbModels;

namespace Tracker.Domain.Entities.RequestModels.Tasks;

public class FindAllByProjectIdRequestModel : IRequest<Result<List<TaskDbModel>>>
{
    public int Id { get; set; }
}