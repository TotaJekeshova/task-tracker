using Ardalis.Result;
using AutoMapper;
using MediatR;
using Tracker.Application.Contracts.Projects;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Features.Projects.Commands.DeleteById;

public class DeleteByIdCommandHandler : IRequestHandler<DeleteProjectRequestModel, Result>
{
    private readonly IChangeProjectRepository _changeProjectRepository;
    private readonly IMapper _mapper;

    public DeleteByIdCommandHandler(IChangeProjectRepository changeProjectRepository, IMapper mapper)
    {
        _changeProjectRepository = changeProjectRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(DeleteProjectRequestModel request, CancellationToken cancellationToken)
    {
        _changeProjectRepository.DeleteProjectById(request);
        return Result.Success();
    }
}