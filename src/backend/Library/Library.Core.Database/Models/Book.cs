using System.ComponentModel.DataAnnotations;

namespace Library.Core.Database.Models;

public class Book
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public Guid AuthorId { get; set; }
    
    public Author? Author { get; set; }
    
    [Required]
    public string Ibnr { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    public ICollection<Genre> Genres { get; set; }
}