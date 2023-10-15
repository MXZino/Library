using Library.Database.Entities;
using Library.Repository.Abstract.Base;
using Library.Repository.Filters;

namespace Library.Repository.Abstract;

public interface IBookRepository : IRepositoryBase<Book>
{
    Book? GetBookWithoutAuthor(Guid id);

    Task<PageResult<Book>> GetBooks(BooksFilter filter);
}