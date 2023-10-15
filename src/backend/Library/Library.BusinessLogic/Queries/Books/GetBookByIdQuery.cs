using Library.Dto.Books;
using MediatR;

namespace Library.BusinessLogic.Queries.Books;

public record GetBookByIdQuery(Guid Id) : IRequest<BookWithAuthorDto>;