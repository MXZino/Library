using Microsoft.Extensions.DependencyInjection;

namespace Library.Configuration.Services.ServiceCollectionExtensions;

public static partial class ServiceCollectionExtensions
{
    public static void Swagger(this IServiceCollection services)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}