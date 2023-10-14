using System.ComponentModel.DataAnnotations;

namespace Library.Dto.Authors;

public class EditAuthorDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    public string Description { get; set; }
}