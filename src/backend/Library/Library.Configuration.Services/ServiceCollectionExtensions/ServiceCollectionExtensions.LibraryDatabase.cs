using Library.Configuration.Extensions;
using Library.Database;
using Library.Repository;
using Library.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Configuration.Services.ServiceCollectionExtensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddLibraryDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options
            => options.UseNpgsql(configuration.GetString(SectionNames.SectionNames.Database.ConnectionString)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}