using System.Data.Common;
using Obavi.Data;
using Obavi.Modules.Users.Core;
using Obavi.Modules.Users.Models;

namespace Obavi.Modules.Users.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserModule(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("user").WithTags("User");

        group.MapGet("/{userId:guid}",
            async (ObaviContext dbContext, Guid userId) =>
            {
                var user = await dbContext.FindAsync<User>(userId);
                return user;
            });
        group.MapDelete("/{userId:guid}",
            async (ObaviContext dbContext, CancellationToken cancellationToken, Guid userId) =>
            {
                dbContext.Remove(new User { Id = userId });
                await dbContext.SaveChangesAsync(cancellationToken);
            });
        group.MapPut("/{userId:guid}",
            async (ObaviContext dbContext, CancellationToken cancellationToken, Guid userId, UpdateUser model) =>
            {
                dbContext.Update(UpdateUser.ToUser(model, userId));
                await dbContext.SaveChangesAsync(cancellationToken);
            });

        group.MapPost("/", async (ObaviContext dbContext, CancellationToken cancellationToken, UpdateUser model) =>
        {
            var user = dbContext.Add(UpdateUser.ToUser(model));
            await dbContext.SaveChangesAsync(cancellationToken);
            return new { user.Entity.Id };
        });
        return endpoints;
    }
}