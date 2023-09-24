namespace Library.Core.Database.Abstract.Interfaces;

public interface ICreation : IEntity
{
    public DateTimeOffset Created { get; }
}