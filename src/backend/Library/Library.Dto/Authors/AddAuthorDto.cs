using System.ComponentModel.DataAnnotations;

namespace Library.Dto.Authors;

public class AddAuthorDto
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateTimeOffset DateOfBirth { get; set; }
    
    public string Description { get; set; }
}