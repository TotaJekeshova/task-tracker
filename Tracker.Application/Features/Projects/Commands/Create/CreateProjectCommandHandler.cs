using Ardalis.Result;
using AutoMapper;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Commands.Create;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectRequestModel, Result<ProjectDbModel>>
{
    private readonly IChangeProjectRepository _changeProjectRepository;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IChangeProjectRepository changeProjectRepository, IMapper mapper)
    {
        _changeProjectRepository = changeProjectRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProjectDbModel>> Handle(CreateProjectRequestModel request, CancellationToken cancellationToken)
    {
        var result = _changeProjectRepository.MapProjectToDefault(request);
        return Result.Success(result);
    }
}