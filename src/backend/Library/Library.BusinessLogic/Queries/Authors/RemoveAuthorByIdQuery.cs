using MediatR;

namespace Library.BusinessLogic.Queries.Authors;

public record RemoveAuthorByIdQuery(Guid UserId) : IRequest;