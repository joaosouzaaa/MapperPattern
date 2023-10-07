namespace Domain.Entities;
public sealed class Engine
{
    public int EngineId { get; set; }
    public required string Type { get; set; }
    public required double Horsepower { get; set; }

    public required int CarId { get; set; }
    public Car Car { get; set; }
}
