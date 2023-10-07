using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class CarFeatureMapping : IEntityTypeConfiguration<CarFeature>
{
    public void Configure(EntityTypeBuilder<CarFeature> builder)
    {
        builder.HasKey(x => x.CarFeatureId);

        builder.Property(c => c.FeatureName)
            .HasColumnType("varchar(50)")
            .HasColumnName("feature_name")
            .IsRequired(true);

        builder.Property(c => c.IsAvailable)
            .HasColumnName("is_available")
            .IsRequired(true);
    }
}
