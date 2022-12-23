using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Features.Tasks.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskRequestModel, Result<TaskDbModel>>
{
    private readonly IChangeTaskRepository _changeTaskRepository;

    public CreateTaskCommandHandler(IChangeTaskRepository changeTaskRepository)
    {
        _changeTaskRepository = changeTaskRepository;
    }

    public async Task<Result<TaskDbModel>> Handle(CreateTaskRequestModel request, CancellationToken cancellationToken)
    {
        var result = _changeTaskRepository.MapTaskToDefault(request);
        return Result.Success(result);
    }
}