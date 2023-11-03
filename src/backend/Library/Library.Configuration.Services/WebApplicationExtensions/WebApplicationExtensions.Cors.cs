using Microsoft.AspNetCore.Builder;

namespace Library.Configuration.Services.WebApplicationExtensions;

public static partial class WebApplicationExtensions
{
    public static void UseCorsPolicy(this WebApplication application)
    {
        application.UseCors("Angular");
    }
}