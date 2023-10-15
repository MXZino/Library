using MediatR;

namespace Library.BusinessLogic.Commands.Books;

public record RemoveBookCommand(Guid Id) : IRequest;