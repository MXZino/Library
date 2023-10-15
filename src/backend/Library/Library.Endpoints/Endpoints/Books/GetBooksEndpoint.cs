using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Queries.Books;
using Library.Dto.Abstract;
using Library.Dto.Books;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Books;

public class GetBooksEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetBooksFilterDto>.WithResult<PageResultDto<BookWithAuthorDto>>
{
    [HttpGet($"{ApiConfiguration.Books}/all")]
    [SwaggerOperation(Summary = "Get books", 
        Description = "Get books", 
        OperationId = "Books_Get",
        Tags = new[] { "Books" })]
    public override async Task<PageResultDto<BookWithAuthorDto>> HandleAsync([FromQuery] GetBooksFilterDto request, CancellationToken cancellationToken = new())
    {
        var results = await mediator.Send(new GetBooksQuery(request), cancellationToken);

        return results;
    }
}