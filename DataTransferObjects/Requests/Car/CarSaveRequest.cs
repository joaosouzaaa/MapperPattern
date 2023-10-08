using DataTransferObjects.Enums;
using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Requests.Color;
using DataTransferObjects.Requests.Engine;

namespace DataTransferObjects.Requests.Car;
public sealed class CarSaveRequest
{
    public required string Model { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public required EFuelTypeRequest FuelType { get; set; }
    public required bool HasNavigationSystem { get; set; }

    public required EngineSaveRequest Engine { get; set; }
    public required List<CarFeatureSaveRequest> CarFeatures { get; set; }
    public required List<ColorSaveRequest> Colors { get; set; }
}
