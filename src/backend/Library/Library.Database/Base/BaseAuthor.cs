using System.ComponentModel.DataAnnotations;

namespace Library.Database.Base;

public abstract class BaseAuthor
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public ICollection<BaseBook> Books { get; set; }
}