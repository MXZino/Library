namespace Library.Core.Database.Abstract.Interfaces;

public interface IModification : IEntity
{
    public DateTimeOffset Modified { get; }
}