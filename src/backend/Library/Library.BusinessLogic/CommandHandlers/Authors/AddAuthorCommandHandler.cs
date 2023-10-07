using Library.AutoMapper.Extensions;
using Library.BusinessLogic.Commands.Authors;
using Library.Repository.Abstract;
using MediatR;

namespace Library.BusinessLogic.CommandHandlers.Authors;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = request.AddAuthorDto.ToEntity();
        
        _unitOfWork.Authors.Add(author);

        await _unitOfWork.Save();
    }
}