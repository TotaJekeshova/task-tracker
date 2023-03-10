using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.API.Endpoints.Projects;

public class GetRangeByDates : EndpointBaseAsync
    .WithRequest<FilteredByDateRequestModel>
    .WithActionResult<List<ProjectDbModel>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetRangeByDates(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/Project/getRange")]
    public override async Task<ActionResult<List<ProjectDbModel>>> HandleAsync([FromQuery] FilteredByDateRequestModel request,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<List<ProjectDbModel>>(result));
    }
}