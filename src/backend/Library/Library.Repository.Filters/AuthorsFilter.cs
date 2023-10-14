using Library.Repository.Filters.Abstract;

namespace Library.Repository.Filters;

public class AuthorsFilter : BasePagination
{
    public string Name { get; set; }
}