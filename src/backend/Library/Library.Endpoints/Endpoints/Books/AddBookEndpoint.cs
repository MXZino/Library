using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Commands.Books;
using Library.Dto.Books;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Books;

public class AddBookEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<AddBookDto>.WithActionResult
{
    [HttpPost(ApiConfiguration.Books)]
    [SwaggerOperation(Summary = "Add new book", 
        Description = "Add new book", 
        OperationId = "Book_Create",
        Tags = new[] { "Books" })]
    public override async Task<ActionResult> HandleAsync(AddBookDto request, CancellationToken cancellationToken = new())
    {
        await mediator.Send(new AddBookCommand(request), cancellationToken);

        return Created();
    }
}