using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Commands.Authors;
using Library.Dto.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Authors;

public class EditAuthorEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<EditAuthorDto>.WithoutResult
{
    [HttpPut]
    [SwaggerOperation(Summary = "Edit author", 
        Description = "Edit author", 
        OperationId = "Author_Edit",
        Tags = new[] { "Authors" })]
    public override async Task<ActionResult> HandleAsync([FromBody] EditAuthorDto request, CancellationToken cancellationToken = new CancellationToken())
    {
        await mediator.Send(new UpdateAuthorCommand(request), cancellationToken);

        return Ok();
    }
}