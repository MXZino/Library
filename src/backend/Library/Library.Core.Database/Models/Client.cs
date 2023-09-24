using System.ComponentModel.DataAnnotations;

namespace Library.Core.Database.Models;

public class Client
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