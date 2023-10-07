namespace Library.Dto.Authors;

public class AuthorWithBooksDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    
    public string Description { get; set; }
    
    public uint NumberOfBooks { get; set; }
    
    public IEnumerable<BookByAuthorDto> Books { get; set; }
    
    public DateTimeOffset Modified { get; set; }
    
    public DateTimeOffset Created { get; }
}

public class BookByAuthorDto
{
    public string Title { get; set; }
    
    public string Ibnr { get; set; }

    public int Year { get; set; }
}