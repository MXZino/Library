using Library.Configuration.Services.ServiceCollectionExtensions;
using Library.Configuration.Services.WebApplicationExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Swagger();

builder.Services.AddLibraryDatabase(builder.Configuration);

var app = builder.Build();

app.MigrateLibraryDb();

app.Swagger();

app.UseHttpsRedirection();

app.Run();