using Library.Repository.Filters.Abstract;

namespace Library.Repository.Filters;

public class BooksFilter : BasePagination
{
    public string Title { get; set; }
    
    public string AuthorName { get; set; }
    
    public int? YearEqualGreaterThan { get; set; }
}