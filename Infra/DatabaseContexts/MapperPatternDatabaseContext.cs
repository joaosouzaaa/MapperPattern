using Microsoft.EntityFrameworkCore;

namespace Infra.DatabaseContexts;
public sealed class MapperPatternDatabaseContext(DbContextOptions<MapperPatternDatabaseContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MapperPatternDatabaseContext).Assembly);
    }
}
