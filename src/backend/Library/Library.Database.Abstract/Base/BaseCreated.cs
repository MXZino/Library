using Library.Database.Abstract.Interfaces;

namespace Library.Database.Abstract.Base;

public abstract class BaseCreated : ICreation
{
    public Guid Id { get; set; }
    public DateTimeOffset Created => DateTimeOffset.Now;
}