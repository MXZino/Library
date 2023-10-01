using Library.Database.Abstract.Interfaces;

namespace Library.Database.Abstract.Base;

public abstract class BaseCreated : BaseEntity, ICreation
{
    public DateTimeOffset Created => DateTimeOffset.Now;
}