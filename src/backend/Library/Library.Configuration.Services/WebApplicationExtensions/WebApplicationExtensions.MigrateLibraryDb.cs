using Library.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Configuration.Services.WebApplicationExtensions;

public static partial class WebApplicationExtensions
{
    public static void MigrateLibraryDb(this WebApplication application)
    {
        using var scope = application!.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        db.Database.Migrate();
    }
}