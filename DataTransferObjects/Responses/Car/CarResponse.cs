using DataTransferObjects.Responses.CarFeature;
using DataTransferObjects.Responses.Color;
using DataTransferObjects.Responses.Engine;

namespace DataTransferObjects.Responses.Car;
public sealed class CarResponse
{
    public required int CarId { get; set; }
    public required string Model { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public required ushort FuelType { get; set; }
    public required bool HasNavigationSystem { get; set; }

    public EngineResponse Engine { get; set; }
    public List<CarFeatureResponse> CarFeatures { get; set; }
    public List<ColorResponse> Colors { get; set; }
}
