using Microsoft.Extensions.DependencyInjection;

namespace Library.Configuration.Services.ServiceCollectionExtensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "Angular",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "http://localhost:8081")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
}