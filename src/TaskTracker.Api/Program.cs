using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Extensions;
using TaskTracker.Storage.Context;
using TaskTracker.Storage.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;

builder.Services.AddDbContext(connectionString);
builder.Services.AddControllers();

var app = builder.Build();

app.Migrate<TaskTrackerContext>();

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

app.Run();
