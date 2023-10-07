using Domain.Enums;

namespace Domain.Entities;
public sealed class Engine
{
    public int EngineId { get; set; }
    public required EEngineType EngineType { get; set; }
    public required double Horsepower { get; set; }
    public required string Description { get; set; }

    public required int CarId { get; set; }
    public Car Car { get; set; }
}
