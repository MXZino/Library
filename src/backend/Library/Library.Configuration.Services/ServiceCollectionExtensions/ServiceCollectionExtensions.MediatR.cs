using Microsoft.Extensions.DependencyInjection;

namespace Library.Configuration.Services.ServiceCollectionExtensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(BusinessLogic.CommandHandlers.Authors.AddAuthorCommandHandler).Assembly);
        });
    }
}