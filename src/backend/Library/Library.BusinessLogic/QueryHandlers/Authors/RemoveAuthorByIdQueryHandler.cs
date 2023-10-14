using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Queries.Authors;
using Library.Database.Entities;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.QueryHandlers.Authors;

public class RemoveAuthorByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveAuthorByIdQuery>
{
    public async Task Handle(RemoveAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = unitOfWork.Authors.Get(request.UserId);

        if (author is null)
            throw new EntityNotFoundException<Author>(request.UserId);
        
        unitOfWork.Authors.Remove(author);

        await unitOfWork.Save();
    }
}