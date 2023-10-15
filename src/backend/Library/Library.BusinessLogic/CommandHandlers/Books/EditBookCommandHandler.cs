using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Commands.Books;
using Library.Database.Entities;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.CommandHandlers.Books;

public class EditBookCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditBookCommand>
{
    public async Task Handle(EditBookCommand request, CancellationToken cancellationToken)
    {
        var book = unitOfWork.Books.GetBookWithoutAuthor(request.Book.Id);

        if (book is null)
            throw new EntityNotFoundException<Book>(request.Book.Id);
        
        request.Book.Map(book);

        await unitOfWork.Save();
    }
}