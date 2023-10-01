using System.ComponentModel.DataAnnotations;
using Library.Database.Abstract.Base;

namespace Library.Database.Entities;

public class Genre : BaseEntity
{
    [Required]
    public string Name { get; set; }
}