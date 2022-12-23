using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.API.Endpoints.Tasks;

public class DeleteById : EndpointBaseAsync
    .WithRequest<DeleteTaskRequestModel>
    .WithActionResult<bool>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DeleteById(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/Task/Delete")]
    public override async Task<ActionResult<bool>> HandleAsync(DeleteTaskRequestModel request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(_mapper.Map<bool>(result));
    }
}