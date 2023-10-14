using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Queries.Authors;
using Library.Dto.Abstract;
using Library.Dto.Authors;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Authors;

public class GetAuthorsEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAuthorsFilterDto>.WithResult<PageResultDto<AuthorWithBooksDto>>
{
    [HttpGet(ApiConfiguration.Authors)]
    [SwaggerOperation(Summary = "Get authors", 
        Description = "Get authors", 
        OperationId = "Authors_Get",
        Tags = new[] { "Authors" })]
    public override async Task<PageResultDto<AuthorWithBooksDto>> HandleAsync([FromQuery] GetAuthorsFilterDto request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await mediator.Send(new GetAuthorsQuery(request), cancellationToken);

        return result;
    }
}