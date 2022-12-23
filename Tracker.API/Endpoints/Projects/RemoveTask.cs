using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.API.Endpoints.Projects;

public class RemoveTask : EndpointBaseAsync
    .WithRequest<RemoveTaskRequestModel>
    .WithActionResult<bool>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RemoveTask(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("/Project/RemoveTask")]
    public override async Task<ActionResult<bool>> HandleAsync(RemoveTaskRequestModel request, CancellationToken cancellationToken = new CancellationToken())
    {
        await _mediator.Send(request, cancellationToken);
        return Ok("Task removed from project");
    }
}