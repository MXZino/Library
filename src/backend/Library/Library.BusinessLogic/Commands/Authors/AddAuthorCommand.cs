using Library.Dto.Authors;
using MediatR;

namespace Library.BusinessLogic.Commands.Authors;

public record AddAuthorCommand(AddAuthorDto AddAuthorDto) : IRequest;
