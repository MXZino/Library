using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Commands.Books;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Books;

public class RemoveAuthorEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<Guid>.WithActionResult
{
    [HttpDelete($"{ApiConfiguration.Books}" + "/{bookId}")]
    [SwaggerOperation(Summary = "Remove book with id", 
        Description = "Remove book", 
        OperationId = "Book_Remove",
        Tags = new[] { "Books" })]
    public override async Task<ActionResult> HandleAsync([FromRoute] Guid bookId, CancellationToken cancellationToken = new CancellationToken())
    {
        await mediator.Send(new RemoveBookCommand(bookId), cancellationToken);

        return NoContent();
    }
}