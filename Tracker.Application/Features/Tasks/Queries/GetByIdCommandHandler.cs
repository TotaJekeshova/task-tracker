using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Features.Tasks.Queries;

public class GetByIdCommandHandler  : IRequestHandler<FindTaskByIdRequestModel, Result<TaskDbModel>>
{
    private readonly IAboutTaskRepository _aboutTaskRepository;
    
    public async Task<Result<TaskDbModel>> Handle(FindTaskByIdRequestModel request, CancellationToken cancellationToken)
    {
        var result = _aboutTaskRepository.GetFirstOrDefaultById(request);
        return Result.Success(result);
    }
}