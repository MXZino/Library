using Library.Dto.Authors;
using MediatR;

namespace Library.BusinessLogic.Queries.Authors;

public record GetAuthorByIdQuery(Guid Id) : IRequest<AuthorWithBooksDto>;