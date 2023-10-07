using Library.Configuration.Extensions;
using Library.Configuration.SectionNames;
using Library.Database.Abstract.Base;
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

    private readonly IConfiguration _configuration;

    public LibraryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseNpgsql(_configuration.GetString(SectionNames.Database.ConnectionString));

    public async Task Save()
    {
        UpdateModifiedTimeStamp();
        await base.SaveChangesAsync();
    }
    
    private void UpdateModifiedTimeStamp()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && e.State is EntityState.Modified or EntityState.Added);
       
        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).Modified = DateTimeOffset.Now;
        }
    }
}