using DataTransferObjects.Responses.CarFeature;
using DataTransferObjects.Responses.Color;
using DataTransferObjects.Responses.Engine;

namespace DataTransferObjects.Responses.Car;
public sealed class CarWithRelationshipsResponse
{
    public required int Id { get; set; }
    public required string Model { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public required ushort FuelType { get; set; }
    public required bool HasNavigationSystem { get; set; }

    public required EngineResponse Engine { get; set; }
    public required List<CarFeatureResponse> CarFeatures { get; set; }
    public required List<ColorResponse> Colors { get; set; }
}
