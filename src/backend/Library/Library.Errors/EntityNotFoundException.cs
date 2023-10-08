using System.Net;
using Library.Database.Abstract.Interfaces;
using Library.Errors.Abstract.Base;

namespace Library.Errors;

public sealed class EntityNotFoundException<TEntity> : BaseAppException where TEntity : IEntity
{
    public override HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;
    
    public EntityNotFoundException(Guid id, Exception innerException)
    {
        Message = $"Entity of type {typeof(TEntity).Name} with id: {id} doesn't exist";
        InnerException = innerException;
    }
    
    public EntityNotFoundException(Guid id)
    {
        Message = $"Entity of type {typeof(TEntity).Name} with id: {id} doesn't exist";
    }
}