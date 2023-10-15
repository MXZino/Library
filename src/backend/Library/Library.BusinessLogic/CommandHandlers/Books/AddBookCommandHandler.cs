using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Commands.Books;
using Library.Database.Entities;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.CommandHandlers.Books;

public class AddBookCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddBookCommand>
{
    public async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        if (!unitOfWork.Authors.Exists(request.Book.AuthorId))
            throw new EntityNotFoundException<Author>(request.Book.AuthorId);

        var book = request.Book.ToEntity();
        
        unitOfWork.Books.Add(book);

        await unitOfWork.Save();
    }
}