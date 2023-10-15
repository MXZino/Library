using MediatR;

namespace Library.BusinessLogic.Commands.Authors;

public record RemoveAuthorByIdCommand(Guid UserId) : IRequest;