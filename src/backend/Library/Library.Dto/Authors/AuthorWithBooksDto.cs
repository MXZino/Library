namespace Library.Dto.Authors;

public class AuthorWithBooksDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }
    
    public string Description { get; set; }
    
    public IEnumerable<BookByAuthorDto> Books { get; set; }
    
    public DateTimeOffset Modified { get; set; }
    
    public DateTimeOffset Created { get; set; }
}

public class BookByAuthorDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    public string Ibnr { get; set; }

    public int Year { get; set; }
}