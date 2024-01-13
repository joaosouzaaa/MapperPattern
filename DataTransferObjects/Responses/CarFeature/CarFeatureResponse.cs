namespace DataTransferObjects.Responses.CarFeature;
public sealed class CarFeatureResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsAvailable { get; set; }
}
