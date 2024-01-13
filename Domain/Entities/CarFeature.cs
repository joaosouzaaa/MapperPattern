namespace Domain.Entities;
public sealed class CarFeature
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsAvailable { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }
}
