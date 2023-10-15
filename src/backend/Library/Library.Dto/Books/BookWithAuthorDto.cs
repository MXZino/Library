namespace Library.Dto.Books;

public class BookWithAuthorDto
{
    public Guid Id { get; set; }
    
    public DateTimeOffset Modified { get; set; }
    
    public DateTimeOffset Created { get; set; }
    
    public string Title { get; set; }
    
    public AuthorByBookDto Author { get; set; }
    
    public string Ibnr { get; set; }
    
    public int Year { get; set; }
}

public class AuthorByBookDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public DateTimeOffset DateOfBirth { get; set; }
    
    public string Description { get; set; }
}