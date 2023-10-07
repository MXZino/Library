using Library.Database.Entities;
using Library.Repository.Abstract.Base;

namespace Library.Repository.Abstract;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }
    IBookRepository Books { get; }
    Task Save();
}