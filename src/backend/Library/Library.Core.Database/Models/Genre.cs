using System.ComponentModel.DataAnnotations;

namespace Library.Core.Database.Models;

public class Genre
{
    [Required]
    public string Name { get; set; }
}