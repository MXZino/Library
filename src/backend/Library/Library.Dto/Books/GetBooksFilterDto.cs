using Library.Dto.Abstract;

namespace Library.Dto.Books;

public class GetBooksFilterDto : BasePaginationDto
{
    public string Title { get; set; }
    
    public string AuthorName { get; set; }
    
    public int? YearEqualGreaterThan { get; set; }
}