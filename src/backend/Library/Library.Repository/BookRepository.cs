using Library.Database;
using Library.Database.Entities;
using Library.Repository.Abstract;
using Library.Repository.Abstract.Base;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public override Book? Get(Guid id)
    {
        return DatabaseContext.Books
            .Include(x => x.Author)
            .FirstOrDefault(x => x.Id == id);
    }
}