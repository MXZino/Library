using System.ComponentModel.DataAnnotations;

namespace Library.Dto.Books;

public class AddBookDto
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public Guid AuthorId { get; set; }
    
    [Required]
    public string Ibnr { get; set; }
    
    [Required]
    public int Year { get; set; }
}