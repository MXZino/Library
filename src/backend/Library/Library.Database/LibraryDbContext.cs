namespace Library.Database;

using Library.Database.Entities;
using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Genre> Genres { get; set; }
}