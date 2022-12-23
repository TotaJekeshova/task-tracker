using Ardalis.Result;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Queries;

public class GetByIdCommandHandler : IRequestHandler<FindProjectByIdRequestModel, 
    Result<ProjectDbModel>>
{
    private readonly IAboutProjectRepository _aboutProjectRepository;

    public GetByIdCommandHandler(IAboutProjectRepository aboutProjectRepository)
    {
        _aboutProjectRepository = aboutProjectRepository;
    }

    public async Task<Result<ProjectDbModel>> Handle(FindProjectByIdRequestModel request, CancellationToken cancellationToken)
    {
        var result = _aboutProjectRepository.GetFirstOrDefaultById(request);
        return Result.Success(result);
    }
}