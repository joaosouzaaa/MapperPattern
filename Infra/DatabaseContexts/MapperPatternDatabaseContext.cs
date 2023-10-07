using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DatabaseContexts;
public sealed class MapperPatternDatabaseContext : DbContext
{
    public MapperPatternDatabaseContext(DbContextOptions<MapperPatternDatabaseContext> options) : base(options)
    {

    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<Color> Colors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MapperPatternDatabaseContext).Assembly);
    }
}
