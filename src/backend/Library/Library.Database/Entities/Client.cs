using System.ComponentModel.DataAnnotations;
using Library.Database.Abstract.Base;

namespace Library.Database.Entities;

public class Client : BaseEntity
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