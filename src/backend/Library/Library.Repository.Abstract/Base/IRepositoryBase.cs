using Library.Database.Abstract.Interfaces;

namespace Library.Repository.Abstract.Base;

public interface IRepositoryBase<T> where T : IEntity
{
    T Get(Guid id);
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Add(T entity);
    void Remove(T entity);
}