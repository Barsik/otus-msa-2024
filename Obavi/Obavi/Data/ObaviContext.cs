using Microsoft.EntityFrameworkCore;
using Obavi.Modules.Users.Core;

namespace Obavi.Data;

public class ObaviContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public ObaviContext(DbContextOptions<ObaviContext> options):base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}