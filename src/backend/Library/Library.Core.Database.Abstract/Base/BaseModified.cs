using Library.Core.Database.Abstract.Interfaces;

namespace Library.Core.Database.Abstract.Base;

public abstract class BaseModified : IModification
{
    public Guid Id { get; set; }
    public DateTimeOffset Modified => DateTimeOffset.Now;
}