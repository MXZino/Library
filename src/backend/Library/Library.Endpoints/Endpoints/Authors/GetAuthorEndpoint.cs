﻿using Ardalis.ApiEndpoints;
using Library.BusinessLogic.Queries.Authors;
using Library.Dto.Authors;
using Library.Endpoints.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Endpoints.Endpoints.Authors;

public class GetAuthorEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<Guid>.WithResult<AuthorWithBooksDto>
{
    [HttpGet($"{ApiConfiguration.Authors}" + "/{authorId}")]
    [SwaggerOperation(Summary = "Get author with id",
        Description = "Get author",
        OperationId = "Author_Get",
        Tags = new[] { "Authors" })]
    public override async Task<AuthorWithBooksDto> HandleAsync([FromRoute] Guid authorId,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await mediator.Send(new GetAuthorByIdQuery(authorId), cancellationToken);

        return result;
    }
}