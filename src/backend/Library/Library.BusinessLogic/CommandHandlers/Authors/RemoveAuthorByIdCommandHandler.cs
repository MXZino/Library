using Library.BusinessLogic.Commands.Authors;
using Library.Database.Entities;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.CommandHandlers.Authors;

public class RemoveAuthorByIdCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveAuthorByIdCommand>
{
    public async Task Handle(RemoveAuthorByIdCommand request, CancellationToken cancellationToken)
    {
        var author = unitOfWork.Authors.Get(request.UserId);

        if (author is null)
            throw new EntityNotFoundException<Author>(request.UserId);
        
        unitOfWork.Authors.Remove(author);

        await unitOfWork.Save();
    }
}