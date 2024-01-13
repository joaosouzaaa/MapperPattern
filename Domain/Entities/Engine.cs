using Domain.Enums;

namespace Domain.Entities;
public sealed class Engine
{
    public int Id { get; set; }
    public required EEngineType Type { get; set; }
    public required double Horsepower { get; set; }
    public required string Description { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }
}
