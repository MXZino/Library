using Library.Database;
using Library.Database.Entities;
using Library.Repository.Abstract;
using Library.Repository.Abstract.Base;
using Library.Repository.Filters;
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

    public Book? GetBookWithoutAuthor(Guid id)
    {
        return DatabaseContext.Books
            .FirstOrDefault(x => x.Id == id);
    }

    public async Task<PageResult<Book>> GetBooks(BooksFilter filter)
    {
        var query = DatabaseContext.Books
            .Include(x => x.Author)
            .OrderBy(x => x.Title)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.AuthorName))
        {
            query = query.Where(x => x.Author.FirstName.ToLower().Contains(filter.AuthorName.ToLower())
                                     || x.Author.LastName.ToLower().Contains(filter.AuthorName.ToLower()));
        }

        if (filter.YearEqualGreaterThan is not null)
        {
            query = query.Where(x => x.Year >= filter.YearEqualGreaterThan);
        }

        var result = await GetPagedResultAsync(query, filter);

        return result;
    }
}