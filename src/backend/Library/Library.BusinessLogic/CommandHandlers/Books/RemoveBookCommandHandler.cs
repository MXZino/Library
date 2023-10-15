using Library.BusinessLogic.Commands.Books;
using Library.Database.Entities;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.CommandHandlers.Books;

public class RemoveBookCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveBookCommand>
{
    public async Task Handle(RemoveBookCommand request, CancellationToken cancellationToken)
    {
        var book = unitOfWork.Books.GetBookWithoutAuthor(request.Id);

        if (book is null)
            throw new EntityNotFoundException<Book>(request.Id);
        
        unitOfWork.Books.Remove(book);

        await unitOfWork.Save();
    }
}