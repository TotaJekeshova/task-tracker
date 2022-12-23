using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Queries;

public class GetFilteredByStartDateCommandHandler : IRequestHandler<FilteredByDateRequestModel, 
    Result<List<ProjectDbModel>>>
{
    private readonly IAboutProjectRepository _aboutProjectRepository;

    public GetFilteredByStartDateCommandHandler(IAboutProjectRepository aboutProjectRepository)
    {
        _aboutProjectRepository = aboutProjectRepository;
    }

    public async Task<Result<List<ProjectDbModel>>> Handle(FilteredByDateRequestModel request, 
        CancellationToken cancellationToken)
    {
        var result = _aboutProjectRepository.GetFilteredByStartDate(request);
        return Result.Success(result);
    }
}