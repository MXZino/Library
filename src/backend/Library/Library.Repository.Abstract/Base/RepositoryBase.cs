using System.Linq.Expressions;
using Library.Database;
using Library.Database.Abstract.Interfaces;
using Library.Dto.Abstract;
using Library.Repository.Filters.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Abstract.Base;

public abstract class RepositoryBase<T>(LibraryDbContext libraryDbContext) : IRepositoryBase<T>
    where T : class, IEntity
{
    protected readonly LibraryDbContext DatabaseContext = libraryDbContext;

    public virtual T? Get(Guid id) => DatabaseContext.Set<T>().FirstOrDefault(x => x.Id == id);

    public virtual IEnumerable<T> GetAll() => DatabaseContext.Set<T>();

    public virtual void Add(T entity) => DatabaseContext.Set<T>().Add(entity);
    
    public void Update(T entity) => DatabaseContext.Set<T>().Update(entity);

    public virtual void Remove(T entity) => DatabaseContext.Set<T>().Remove(entity);
    public virtual bool Exists(Guid id) => DatabaseContext.Set<T>().Any(x => x.Id == id);
    protected async Task<PageResult<T>> GetPagedResultAsync(IQueryable<T> query, BasePagination basePaginationDto)
    {
        var totalCount = await query.CountAsync();

        var totalPages = (int)Math.Ceiling(totalCount / (double)basePaginationDto.RecordsPerPage);

        if (basePaginationDto.Page > totalPages) {
            return new PageResult<T> {
                CurrentPage = basePaginationDto.Page,
                TotalPages = totalPages,
                PageSize = basePaginationDto.RecordsPerPage,
                TotalCount = totalCount,
                Items = new List<T>()
            };
        }

        var itemsToSkip = (basePaginationDto.Page - 1) * basePaginationDto.RecordsPerPage;
        
        var items = await query.Skip((int)itemsToSkip)
            .Take((int)basePaginationDto.RecordsPerPage).ToListAsync();

        var result = new PageResult<T>
        {
            Items = items,
            CurrentPage = basePaginationDto.Page,
            TotalPages = totalPages,
            PageSize = basePaginationDto.RecordsPerPage,
            TotalCount = totalCount,
        };

        return result;
    }
}