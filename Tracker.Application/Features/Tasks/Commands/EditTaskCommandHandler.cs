using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Features.Tasks.Commands;

public class EditTaskCommandHandler : IRequestHandler<EditTaskRequestModel, Result<TaskDbModel>>
{
    private readonly IChangeTaskRepository _changeTaskRepository;

    public EditTaskCommandHandler(IChangeTaskRepository changeTaskRepository)
    {
        _changeTaskRepository = changeTaskRepository;
    }


    public async Task<Result<TaskDbModel>> Handle(EditTaskRequestModel request, CancellationToken cancellationToken)
    {
        var result = _changeTaskRepository.EditTask(request);
        return Result.Success(result);
    }
}