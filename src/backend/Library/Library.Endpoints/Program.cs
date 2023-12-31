using Library.Configuration.Services.ServiceCollectionExtensions;
using Library.Configuration.Services.WebApplicationExtensions;
using Library.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCorsPolicy();

builder.Services.Swagger();

builder.Services.AddLibraryDatabase(builder.Configuration);

builder.Services.AddMediatR();

var app = builder.Build();

app.UseCorsPolicy();

app.MigrateLibraryDb();

app.UseLibraryExceptionHandler();

app.Swagger();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();