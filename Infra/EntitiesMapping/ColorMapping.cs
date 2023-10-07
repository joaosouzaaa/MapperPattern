using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class ColorMapping : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(x => x.ColorId);

        builder.Property(c => c.ColorName)
            .HasColumnType("varchar(50)")
            .HasColumnName("color_name")
            .IsRequired(true);
    }
}
