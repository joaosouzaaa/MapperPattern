using Domain.Enums;

namespace Domain.Entities;
public sealed class Car
{
    public int CarId { get; set; }
    public required string Model { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public required EFuelType FuelType { get; set; }
    public required bool HasNavigationSystem { get; set; }

    public Engine Engine { get; set; } 
    public List<CarFeature> CarFeatures { get; set; }
    public List<Color> Colors { get; set; }
}
