using Library.Database.Entities;
using Library.Repository.Abstract.Base;
using Library.Repository.Filters;

namespace Library.Repository.Abstract;

public interface IAuthorRepository : IRepositoryBase<Author>
{
    Task<PageResult<Author>> GetAuthors(AuthorsFilter filter);
}