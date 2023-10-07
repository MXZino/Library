using Library.Database.Abstract.Interfaces;

namespace Library.Database.Abstract.Base;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTimeOffset Modified { get; set; }
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
}