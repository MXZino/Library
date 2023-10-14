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
            .Where(x => x.FirstName.Contains(filter.Name, StringComparison.CurrentCultureIgnoreCase) ||
                        x.LastName.Contains(filter.Name, StringComparison.CurrentCultureIgnoreCase) ||
                        $"{x.FirstName} {x.LastName}".Contains(filter.Name, StringComparison.CurrentCultureIgnoreCase))
            .AsQueryable();

        var result = await GetPagedResultAsync(query, filter);

        return result;
    }
}