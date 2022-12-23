using Ardalis.Result;
using AutoMapper;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Commands.AddTask;

public class AddTaskCommandHandler : IRequestHandler<AddTaskRequestModel, Result<ProjectDbModel>>
{
    private readonly IChangeProjectRepository _changeProjectRepository;
    private readonly IMapper _mapper;

    public AddTaskCommandHandler(IChangeProjectRepository changeProjectRepository, IMapper mapper)
    {
        _changeProjectRepository = changeProjectRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProjectDbModel>> Handle(AddTaskRequestModel request, CancellationToken cancellationToken)
    {
        var result = _changeProjectRepository.AddTask(request);
        return Result.Success(result);
    }
}