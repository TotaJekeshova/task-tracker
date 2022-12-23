using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Commands.RemoveTask;

public class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskRequestModel, Result>
{
    private readonly IChangeProjectRepository _changeProjectRepository;

    public RemoveTaskCommandHandler(IChangeProjectRepository changeProjectRepository)
    {
        _changeProjectRepository = changeProjectRepository;
    }

    public async Task<Result> Handle(RemoveTaskRequestModel request, CancellationToken cancellationToken)
    {
         _changeProjectRepository.RemoveTask(request);
        return Result.Success();
    }
}