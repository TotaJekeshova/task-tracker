using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Queries;

public class GetRangeByDatesCommandHandler : IRequestHandler<FilteredByDateRequestModel, 
    Result<List<ProjectDbModel>>>
{
    private readonly IAboutProjectRepository _aboutProjectRepository;

    public GetRangeByDatesCommandHandler(IAboutProjectRepository aboutProjectRepository)
    {
        _aboutProjectRepository = aboutProjectRepository;
    }

    public async Task<Result<List<ProjectDbModel>>> Handle(FilteredByDateRequestModel request, 
        CancellationToken cancellationToken)
    {
        var result = _aboutProjectRepository.GetRangeByDates(request.StartDate, request.EndDate);
        return Result.Success(result);
    }
}