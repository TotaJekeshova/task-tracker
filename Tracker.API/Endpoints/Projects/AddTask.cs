using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.API.Endpoints.Projects;

public class AddTask : EndpointBaseAsync
    .WithRequest<AddTaskRequestModel>
    .WithActionResult<ProjectDbModel>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AddTask(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("/Project/AddTask")]
    public override async Task<ActionResult<ProjectDbModel>> HandleAsync(AddTaskRequestModel request, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<ProjectDbModel>(result));
    }
}