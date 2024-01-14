namespace DataTransferObjects.Responses.Car;
public sealed class CarResponse
{
    public required int Id { get; set; }
    public required string Model { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public required ushort FuelType { get; set; }
    public required bool HasNavigationSystem { get; set; }
}
