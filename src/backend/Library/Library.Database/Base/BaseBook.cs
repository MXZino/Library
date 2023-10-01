using System.ComponentModel.DataAnnotations;

namespace Library.Database.Base;

public abstract class BaseBook
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public Guid AuthorId { get; set; }
    
    public BaseAuthor? Author { get; set; }
    
    [Required]
    public string Ibnr { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    public ICollection<BaseGenre> Genres { get; set; }
}