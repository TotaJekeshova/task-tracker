using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Projects;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.API.Endpoints.Tasks;

public class Create : EndpointBaseAsync
    .WithRequest<CreateTaskRequestModel>
    .WithActionResult<TaskDbModel>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public Create(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/Task/Create")]
    public override async Task<ActionResult<TaskDbModel>> HandleAsync(CreateTaskRequestModel request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<TaskDbModel>(result));
    }
}