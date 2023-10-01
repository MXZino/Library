using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Library.Configuration.Services.WebApplicationExtensions;

public static partial class WebApplicationExtensions
{
    public static void Swagger(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }
    }
}