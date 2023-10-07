namespace Domain.Entities;
public sealed class CarFeature
{
    public int CarFeatureId { get; set; }
    public required string FeatureName { get; set; }
    public required bool IsAvailable { get; set; }

    public required int CarId { get; set; }
    public Car Car { get; set; }
}
