using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Features.Tasks.Queries;

public class GetAllByProjectIdCommandHandler: IRequestHandler<FindAllByProjectIdRequestModel, Result<List<TaskDbModel>>>
{
    private readonly IAboutTaskRepository _aboutTaskRepository;

    public GetAllByProjectIdCommandHandler(IAboutTaskRepository aboutTaskRepository)
    {
        _aboutTaskRepository = aboutTaskRepository;
    }


    public async Task<Result<List<TaskDbModel>>> Handle(FindAllByProjectIdRequestModel request, CancellationToken cancellationToken)
    {
        var result = _aboutTaskRepository.GetAllByProjectId(request.Id);
        return Result.Success(result);
    }
}