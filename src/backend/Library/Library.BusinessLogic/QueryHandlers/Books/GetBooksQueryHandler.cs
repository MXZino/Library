using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Queries.Books;
using Library.Dto.Abstract;
using Library.Dto.Books;
using Library.Repository.Abstract;
using Library.Repository.Filters;
using MediatR;

namespace Library.BusinessLogic.QueryHandlers.Books;

public class GetBooksQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBooksQuery, PageResultDto<BookWithAuthorDto>>
{
    public async Task<PageResultDto<BookWithAuthorDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var filter = new BooksFilter
        {
            Page = request.Filter.Page,
            Title = request.Filter.Title,
            AuthorName = request.Filter.AuthorName,
            RecordsPerPage = request.Filter.RecordsPerPage,
            YearEqualGreaterThan = request.Filter.YearEqualGreaterThan
        };

        var results = await unitOfWork.Books.GetBooks(filter);

        return results.ToBooksWithAuthors();
    }
}