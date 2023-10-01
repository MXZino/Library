using Library.Database.Abstract.Interfaces;

namespace Library.Database.Abstract.Base;

public abstract class BaseModified : IModification
{
    public Guid Id { get; set; }
    public DateTimeOffset Modified => DateTimeOffset.Now;
}