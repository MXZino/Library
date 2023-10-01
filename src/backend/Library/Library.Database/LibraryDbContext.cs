using Library.Configuration.Extensions;
using Library.Configuration.SectionNames;
using Microsoft.Extensions.Configuration;

namespace Library.Database;

using Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Library DbContext class.
/// </summary>
public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Genre> Genres { get; set; }

    private readonly IConfiguration _configuration;

    public LibraryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseNpgsql(_configuration.GetString(SectionNames.Database.ConnectionString));
}