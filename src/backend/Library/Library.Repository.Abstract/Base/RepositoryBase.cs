using Library.Database;
using Library.Database.Abstract.Interfaces;

namespace Library.Repository.Abstract.Base;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
{
    protected readonly LibraryDbContext DatabaseContext;
    
    public RepositoryBase(LibraryDbContext libraryDbContext)
    {
        DatabaseContext = libraryDbContext;
    }
    
    public virtual T? Get(Guid id) => DatabaseContext.Set<T>().FirstOrDefault(x => x.Id == id);

    public virtual IEnumerable<T> GetAll() => DatabaseContext.Set<T>();

    public virtual void Add(T entity) => DatabaseContext.Set<T>().Add(entity);
    
    public void Update(T entity) => DatabaseContext.Set<T>().Update(entity);

    public virtual void Remove(T entity) => DatabaseContext.Set<T>().Remove(entity);
}