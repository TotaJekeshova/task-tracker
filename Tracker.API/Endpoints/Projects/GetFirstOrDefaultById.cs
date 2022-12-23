using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.API.Endpoints.Projects;

public class GetFirstOrDefaultById : EndpointBaseAsync
    .WithRequest<FindProjectByIdRequestModel>
    .WithActionResult<ProjectDbModel>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetFirstOrDefaultById(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/Project/getById")]
    public override async Task<ActionResult<ProjectDbModel>> HandleAsync(FindProjectByIdRequestModel request, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<List<ProjectDbModel>>(result));
    }
}