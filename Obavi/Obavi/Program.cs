using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", () => "Obavi");

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (ctx, _) =>
    {
        ctx.Response.ContentType = MediaTypeNames.Application.Json;
        await ctx.Response.WriteAsync(JsonSerializer.Serialize(new { status = "OK" }));
    },
});

app.Run();