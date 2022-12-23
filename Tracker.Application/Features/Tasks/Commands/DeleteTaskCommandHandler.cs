using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Tasks.Commands;
 
public class DeleteTaskCommandHandler : IRequestHandler<DeleteProjectRequestModel, Result>
{
    private readonly IChangeTaskRepository _changeTaskRepository;

    public DeleteTaskCommandHandler(IChangeTaskRepository changeTaskRepository)
    {
        _changeTaskRepository = changeTaskRepository;
    }

    public async Task<Result> Handle(DeleteProjectRequestModel request, CancellationToken cancellationToken)
    {
        _changeTaskRepository.DeleteTaskById(request);
        return Result.Success();
    }
}