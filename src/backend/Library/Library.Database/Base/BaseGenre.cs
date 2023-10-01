using System.ComponentModel.DataAnnotations;

namespace Library.Database.Base;

public abstract class BaseGenre
{
    [Required]
    public string Name { get; set; }
}