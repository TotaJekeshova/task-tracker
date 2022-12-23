using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Features.Tasks.Commands;
 
public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskRequestModel, Result>
{
    private readonly IChangeTaskRepository _changeTaskRepository;

    public DeleteTaskCommandHandler(IChangeTaskRepository changeTaskRepository)
    {
        _changeTaskRepository = changeTaskRepository;
    }

    public async Task<Result> Handle(DeleteTaskRequestModel request, CancellationToken cancellationToken)
    {
        _changeTaskRepository.DeleteTaskById(request);
        return Result.Success();
    }
}