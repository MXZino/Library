using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Queries.Authors;
using Library.Database.Entities;
using Library.Dto.Authors;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.QueryHandlers.Authors;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorWithBooksDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<AuthorWithBooksDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = _unitOfWork.Authors.Get(request.Id);

        if (author is null)
            throw new EntityNotFoundException<Author>(request.Id);
        
        return Task.FromResult(author.ToAuthorWithBooksDto());
    }
}