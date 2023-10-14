using Library.Database;
using Library.Database.Entities;
using Library.Repository.Abstract;
using Library.Repository.Abstract.Base;
using Library.Repository.Filters;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<PageResult<Author>> GetAuthors(AuthorsFilter filter)
    {
        var query = DatabaseContext.Authors
            .Include(x => x.Books)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(x => x.FirstName.Contains(filter.Name) || x.LastName.Contains(filter.Name));
        }

        var result = await GetPagedResultAsync(query, filter);

        return result;
    }
}