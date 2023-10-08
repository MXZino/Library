using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Queries.Authors;
using Library.Dto.Authors;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Authors;

public class GetAuthorEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithResult<AuthorWithBooksDto>
{
    private readonly IMediator _mediator;

    public GetAuthorEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet(ApiConfiguration.Authors)]
    [SwaggerOperation(Summary = "Get author with id", 
        Description = "Get author", 
        OperationId = "Author_Get",
        Tags = new[] { "Authors" })]
    public override async Task<AuthorWithBooksDto> HandleAsync([FromQuery] Guid authorId, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(new GetAuthorByIdQuery(authorId), cancellationToken);
        
        return result;
    }
}