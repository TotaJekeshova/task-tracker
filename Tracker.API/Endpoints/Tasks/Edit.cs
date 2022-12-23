using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.API.Endpoints.Tasks;

public class Edit : EndpointBaseAsync
    .WithRequest<EditTaskRequestModel>
    .WithActionResult<TaskDbModel>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public Edit(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/Task/Edit")]
    public override async Task<ActionResult<TaskDbModel>> HandleAsync(EditTaskRequestModel request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<TaskDbModel>(result));
    }
}