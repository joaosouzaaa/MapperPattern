namespace Domain.Entities;
public sealed class Manufacturer
{
    public required int ManufacturerId { get; set; }
    public required string Name { get; set; }

    public List<Car> Cars { get; set; }
}
