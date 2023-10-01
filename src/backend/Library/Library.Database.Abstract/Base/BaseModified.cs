using Library.Database.Abstract.Interfaces;

namespace Library.Database.Abstract.Base;

public abstract class BaseModified : BaseEntity, IModification
{
    public DateTimeOffset Modified => DateTimeOffset.Now;
}