using Library.Dto.Abstract;
using Library.Dto.Books;
using MediatR;

namespace Library.BusinessLogic.Queries.Books;

public record GetBooksQuery(GetBooksFilterDto Filter) : IRequest<PageResultDto<BookWithAuthorDto>>;