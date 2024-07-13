using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Obavi.Common;
using Obavi.Data;
using Obavi.Modules.Users.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = ConnectionStringBuilder.Build(builder.Configuration);

if (args.Contains("--run-migrations"))
{
    DbContextOptionsBuilder<ObaviContext> optionsBuilder = new();
    optionsBuilder.UseNpgsql(connectionString);
    var context = new ObaviContext(optionsBuilder.Options);
    context.Database.Migrate();
    Environment.Exit(0);
}

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<ObaviContext>(options =>
{
    options.UseNpgsql(connectionString);
});
var app = builder.Build();

app.MapUserModule();

app.MapGet("/", () => "Obavi");

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (ctx, _) =>
    {
        ctx.Response.ContentType = MediaTypeNames.Application.Json;
        await ctx.Response.WriteAsync(JsonSerializer.Serialize(new { status = "OK" }));
    },
});


app.UseSwagger();
app.UseSwaggerUI();

app.Run();