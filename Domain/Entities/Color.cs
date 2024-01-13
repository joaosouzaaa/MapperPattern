namespace Domain.Entities;
public sealed class Color
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Car> Cars { get; set; } 
}
