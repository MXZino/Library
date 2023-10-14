using Library.Dto.Authors;
using MediatR;

namespace Library.BusinessLogic.Commands.Authors;

public record UpdateAuthorCommand(EditAuthorDto Author) : IRequest;
