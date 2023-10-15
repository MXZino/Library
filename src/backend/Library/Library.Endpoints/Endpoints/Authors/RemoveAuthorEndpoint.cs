using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Commands.Authors;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Authors;

public class RemoveAuthorEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<Guid>.WithActionResult
{
    [HttpDelete(ApiConfiguration.Authors)]
    [SwaggerOperation(Summary = "Remove author with id", 
        Description = "Remove author", 
        OperationId = "Author_Remove",
        Tags = new[] { "Authors" })]
    public override async Task<ActionResult> HandleAsync([FromQuery] Guid request, CancellationToken cancellationToken = new CancellationToken())
    {
        await mediator.Send(new RemoveAuthorByIdCommand(request), cancellationToken);

        return NoContent();
    }
}