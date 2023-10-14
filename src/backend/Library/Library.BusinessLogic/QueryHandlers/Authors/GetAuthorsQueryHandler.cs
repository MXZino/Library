using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Queries.Authors;
using Library.Dto.Abstract;
using Library.Dto.Authors;
using Library.Repository.Abstract;
using Library.Repository.Filters;
using MediatR;

namespace Library.BusinessLogic.QueryHandlers.Authors;

public class GetAuthorsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAuthorsQuery, PageResultDto<AuthorWithBooksDto>>
{
    public async Task<PageResultDto<AuthorWithBooksDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authorFilter = new AuthorsFilter
        {
            RecordsPerPage = request.Filter.RecordsPerPage,
            Name = request.Filter.Name,
            Page = request.Filter.Page
        };

        var results = await unitOfWork.Authors.GetAuthors(authorFilter);

        return results.ToAuthorsWithBooksDto();
    }
}