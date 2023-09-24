﻿using System.ComponentModel.DataAnnotations;

namespace Library.Core.Database.Models;

public class Author
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public ICollection<Book> Books { get; set; }
}