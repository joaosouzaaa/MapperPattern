using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesMapping;
public sealed class CarMapping : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable(nameof(Car));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Model)
            .HasColumnType("varchar(50)")
            .HasColumnName("model")
            .IsRequired(true);

        builder.Property(c => c.Year)
            .HasColumnType("int")
            .HasColumnName("year")
            .IsRequired(true);

        builder.Property(c => c.Price)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("price")
            .IsRequired(true);

        builder.Property(c => c.RegistrationDate)
            .HasColumnType("datetime2")
            .HasColumnName("registration_date")
            .IsRequired(true);

        builder.Property(c => c.FuelType)
            .HasColumnName("fuel_type")
            .IsRequired(true);

        builder.Property(c => c.HasNavigationSystem)
            .HasColumnName("has_navigation_system")
            .IsRequired(true);

        builder.HasOne(c => c.Engine)
            .WithOne(e => e.Car)
            .HasForeignKey<Engine>(e => e.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.CarFeatures)
            .WithOne(c => c.Car)
            .HasForeignKey(c => c.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Colors)
            .WithMany(c => c.Cars)
            .UsingEntity<Dictionary<string, object>>("CarsColors", configuration =>
            {
                configuration.HasOne<Car>().WithMany().HasForeignKey("CarsId");
                configuration.HasOne<Color>().WithMany().HasForeignKey("ColorsId");
            });
    }
}
