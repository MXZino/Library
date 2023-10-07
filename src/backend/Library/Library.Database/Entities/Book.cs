using System.ComponentModel.DataAnnotations;
using Library.Database.Abstract.Base;

namespace Library.Database.Entities;

public class Book : BaseEntity
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public Guid AuthorId { get; set; }
    
    public Author Author { get; set; }
    
    [Required]
    public string Ibnr { get; set; }
    
    [Required]
    public int Year { get; set; }
    
}