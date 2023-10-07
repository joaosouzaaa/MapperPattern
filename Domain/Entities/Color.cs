namespace Domain.Entities;
public sealed class Color
{
    public required int ColorId { get; set; }
    public required string ColorName { get; set; }

    public List<Car> Cars { get; set; } 
}
