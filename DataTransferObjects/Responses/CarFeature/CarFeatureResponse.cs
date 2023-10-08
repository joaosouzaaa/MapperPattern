namespace DataTransferObjects.Responses.CarFeature;
public sealed class CarFeatureResponse
{
    public required int CarFeatureId { get; set; }
    public required string FeatureName { get; set; }
    public required bool IsAvailable { get; set; }
}
