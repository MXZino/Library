using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Queries.Books;
using Library.Dto.Books;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Books;

public class GetBookEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<Guid>.WithResult<BookWithAuthorDto>
{
    [HttpGet($"{ApiConfiguration.Books}" + "/{bookId}")]
    [SwaggerOperation(Summary = "Get book with id", 
        Description = "Get book", 
        OperationId = "Book_Get",
        Tags = new[] { "Books" })]
    public override async Task<BookWithAuthorDto> HandleAsync([FromRoute] Guid bookId, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await mediator.Send(new GetBookByIdQuery(bookId), cancellationToken);
        
        return result;
    }
}