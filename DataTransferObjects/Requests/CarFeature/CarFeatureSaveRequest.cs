namespace DataTransferObjects.Requests.CarFeature;
public sealed class CarFeatureSaveRequest
{
    public required string FeatureName { get; set; }
    public required bool IsAvailable { get; set; }
}
