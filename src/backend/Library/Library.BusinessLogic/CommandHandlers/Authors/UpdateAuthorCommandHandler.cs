using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Commands.Authors;
using Library.Database.Entities;
using Library.Errors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.CommandHandlers.Authors;

public class UpdateAuthorCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = unitOfWork.Authors.Get(request.Author.Id);

        if (author is null)
            throw new EntityNotFoundException<Author>(request.Author.Id);
        
        request.Author.Map(author);

        await unitOfWork.Save();
    }
}