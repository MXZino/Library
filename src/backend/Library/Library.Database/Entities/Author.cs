﻿using System.ComponentModel.DataAnnotations;
using Library.Database.Abstract.Base;

namespace Library.Database.Entities;

public class Author : BaseEntity
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateTimeOffset DateOfBirth { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<Book> Books { get; set; }
}