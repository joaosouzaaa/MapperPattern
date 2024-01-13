using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class CarFeatureMapping : IEntityTypeConfiguration<CarFeature>
{
    public void Configure(EntityTypeBuilder<CarFeature> builder)
    {
        builder.ToTable(nameof(CarFeature));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(50)")
            .HasColumnName("name")
            .IsRequired(true);

        builder.Property(c => c.IsAvailable)
            .HasColumnName("is_available")
            .IsRequired(true);
    }
}
