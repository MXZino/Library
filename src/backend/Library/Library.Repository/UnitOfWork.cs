using System.Diagnostics;
using Library.Database;
using Library.Database.Entities;
using Library.Repository.Abstract;
using Library.Repository.Abstract.Base;

namespace Library.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;

    public UnitOfWork(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IAuthorRepository Authors => new AuthorRepository(_dbContext);

    public IBookRepository Books => new BookRepository(_dbContext);
    
    public async Task Save() => await _dbContext.SaveChangesAsync();

    public void Dispose()
    {
        _dbContext.Dispose();
    }
    
}