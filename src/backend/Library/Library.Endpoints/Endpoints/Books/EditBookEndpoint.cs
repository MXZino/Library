using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Commands.Books;
using Library.Dto.Books;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Books;

public class EditBookEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<EditBookDto>.WithoutResult
{
    [HttpPut(ApiConfiguration.Books)]
    [SwaggerOperation(Summary = "Edit book", 
        Description = "Edit book", 
        OperationId = "Book_Edit",
        Tags = new[] { "Books" })]
    public override async Task<ActionResult> HandleAsync([FromBody] EditBookDto request, CancellationToken cancellationToken = new())
    {
        await mediator.Send(new EditBookCommand(request), cancellationToken);

        return Ok();
    }
}