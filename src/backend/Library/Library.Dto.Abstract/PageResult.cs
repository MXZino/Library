namespace Library.Dto.Abstract;

public abstract class PageResult<TDto>
{
    public List<TDto> Items { get; set; } 
    
    public int CurrentPage { get; set; } 
    
    public int TotalPages { get; set; }
    
    public int PageSize { get; set; }
    
    public int TotalCount { get; set; }

    public bool HasPreviousPage => (CurrentPage > 1);
    
    public bool HasNextPage => (CurrentPage < TotalPages);
}