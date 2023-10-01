namespace Library.Database.Abstract.Interfaces;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; }
}