using Library.Dto.Books;
using MediatR;

namespace Library.BusinessLogic.Commands.Books;

public record AddBookCommand(AddBookDto Book) : IRequest;
