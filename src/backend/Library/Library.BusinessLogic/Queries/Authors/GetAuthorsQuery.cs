using Library.Dto.Abstract;
using Library.Dto.Authors;
using MediatR;

namespace Library.BusinessLogic.Queries.Authors;

public record GetAuthorsQuery(GetAuthorsFilterDto Filter) : IRequest<PageResultDto<AuthorWithBooksDto>>;