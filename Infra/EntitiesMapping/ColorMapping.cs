using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class ColorMapping : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable(nameof(Color));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(50)")
            .HasColumnName("name")
            .IsRequired(true);
    }
}
