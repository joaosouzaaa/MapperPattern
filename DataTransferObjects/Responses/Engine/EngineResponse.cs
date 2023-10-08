namespace DataTransferObjects.Responses.Engine;
public sealed class EngineResponse
{
    public int EngineId { get; set; }
    public required ushort EngineType { get; set; }
    public required double Horsepower { get; set; }
    public required string Description { get; set; }
}
