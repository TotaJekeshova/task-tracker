using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.API.Endpoints.Tasks;

public class GetAllByProjectId: EndpointBaseAsync
    .WithRequest<FindAllByProjectIdRequestModel>
    .WithActionResult<List<TaskDbModel>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetAllByProjectId(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/Task/getAllByProject")]
    public override async Task<ActionResult<List<TaskDbModel>>> HandleAsync([FromQuery] FindAllByProjectIdRequestModel request, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<List<TaskDbModel>>(result));
    }
}