namespace Library.Dto.Authors;

public class AuthorWithNumberOfBooksDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    
    public string Description { get; set; }
    
    public uint NumberOfBooks { get; set; }
    
    public DateTimeOffset Modified { get; set; }
    
    public DateTimeOffset Created { get; }
}