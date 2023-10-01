using System.ComponentModel.DataAnnotations;

namespace Library.Database.Base;

public abstract class BaseClient
{
    [Required] 
    public string FirstName { get; set; }

    [Required] 
    public string LastName { get; set; }
    
    [Required]
    public DateTimeOffset DateOfBirth { get; set; }
    
    [Required]
    public string PeselNumber { get; set; }
}