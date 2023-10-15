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
            .OrderBy(x => x.LastName)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(x => x.FirstName.ToLower().Contains(filter.Name.ToLower())
                                     || x.LastName.ToLower().Contains(filter.Name.ToLower()));
        }

        var result = await GetPagedResultAsync(query, filter);

        return result;
    }
}