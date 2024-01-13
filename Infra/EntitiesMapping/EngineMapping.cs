using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class EngineMapping : IEntityTypeConfiguration<Engine>
{
    public void Configure(EntityTypeBuilder<Engine> builder)
    {
        builder.ToTable(nameof(Engine));

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Type)
            .HasColumnName("type")
            .IsRequired(true);

        builder.Property(e => e.Horsepower)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("horsepower")
            .IsRequired(true);

        builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(400)")
            .IsRequired(true);
    }
}
