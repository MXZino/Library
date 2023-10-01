using System.ComponentModel.DataAnnotations;

namespace Library.Database.Models;

public class Genre
{
    [Required]
    public string Name { get; set; }
}