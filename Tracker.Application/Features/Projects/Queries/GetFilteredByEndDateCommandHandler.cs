using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Queries;

public class GetFilteredByEndDateCommandHandler : IRequestHandler<FilteredByEndDateRequestModel, 
    Result<List<ProjectDbModel>>>
{
    private readonly IAboutProjectRepository _aboutProjectRepository;

    public GetFilteredByEndDateCommandHandler(IAboutProjectRepository aboutProjectRepository)
    {
        _aboutProjectRepository = aboutProjectRepository;
    }

    public async Task<Result<List<ProjectDbModel>>> Handle(FilteredByEndDateRequestModel request, 
        CancellationToken cancellationToken)
    {
        var result = _aboutProjectRepository.GetFilteredByEndDate(request.EndDate);
        return Result.Success(result);
    }
}