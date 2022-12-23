using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.API.Endpoints.Projects;

public class DeleteById : EndpointBaseAsync
    .WithRequest<DeleteProjectRequestModel>
    .WithActionResult<bool>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DeleteById(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/Project/Delete")]
    public override async Task<ActionResult<bool>> HandleAsync(DeleteProjectRequestModel request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}