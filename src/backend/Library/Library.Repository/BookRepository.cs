using Library.Database;
using Library.Database.Entities;
using Library.Repository.Abstract;
using Library.Repository.Abstract.Base;

namespace Library.Repository;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}