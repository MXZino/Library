using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Queries.Books;
using Library.Database.Entities;
using Library.Dto.Books;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.QueryHandlers.Books;

public class GetBookByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBookByIdQuery, BookWithAuthorDto>
{
    public Task<BookWithAuthorDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = unitOfWork.Books.Get(request.Id);

        if (book is null)
            throw new EntityNotFoundException<Book>(request.Id);

        var dto = book.ToBookWithAuthorDto();

        return Task.FromResult(dto);
    }
}