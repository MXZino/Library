namespace Library.Dto.Abstract;

public class PageResultDto<TDto>
{
    public List<TDto> Items { get; set; } 
    
    public int CurrentPage { get; set; } 
    
    public int TotalPages { get; set; }
    
    public uint PageSize { get; set; }
    
    public int TotalCount { get; set; }

    public bool HasPreviousPage => (CurrentPage > 1);
    
    public bool HasNextPage => (CurrentPage < TotalPages);
}