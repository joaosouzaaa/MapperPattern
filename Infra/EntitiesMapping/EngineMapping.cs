using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class EngineMapping : IEntityTypeConfiguration<Engine>
{
    public void Configure(EntityTypeBuilder<Engine> builder)
    {
        builder.HasKey(x => x.EngineId);

        builder.Property(e => e.EngineType)
            .HasColumnName("engine_type")
            .IsRequired(true);

        builder.Property(e => e.Horsepower)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("horsepower")
            .IsRequired(true);

        builder.Property(e => e.Description)
            .HasColumnName("varchar(400)")
            .HasColumnType("description")
            .IsRequired(true);
    }
}
