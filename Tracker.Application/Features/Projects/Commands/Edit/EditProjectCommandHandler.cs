using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Commands.Edit;

public class EditProjectCommandHandler : IRequestHandler<EditProjectRequestModel, Result<ProjectDbModel>>
{
    private readonly IChangeProjectRepository _changeProjectRepository;

    public EditProjectCommandHandler(IChangeProjectRepository changeProjectRepository)
    {
        _changeProjectRepository = changeProjectRepository;
    }

    public async Task<Result<ProjectDbModel>> Handle(EditProjectRequestModel request, CancellationToken cancellationToken)
    {
        var result = _changeProjectRepository.EditProject(request);
        return Result.Success(result);
    }
}