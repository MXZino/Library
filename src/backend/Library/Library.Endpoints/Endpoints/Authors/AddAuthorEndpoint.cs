using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Commands.Authors;
using Library.Dto.Authors;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Authors;

public class AddAuthorEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<AddAuthorDto>.WithActionResult
{
    [HttpPost(ApiConfiguration.Authors)]
    [SwaggerOperation(Summary = "Add new author", 
        Description = "Add new author", 
        OperationId = "Author_Create",
        Tags = new[] { "Authors" })]
    public override async Task<ActionResult> HandleAsync(AddAuthorDto request,
        CancellationToken cancellationToken = new())
    {
        await mediator.Send(new AddAuthorCommand(request), cancellationToken);

        return Created();
    }
}

