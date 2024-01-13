namespace DataTransferObjects.Responses.Engine;
public sealed class EngineResponse
{
    public required int Id { get; set; }
    public required ushort Type { get; set; }
    public required double Horsepower { get; set; }
    public required string Description { get; set; }
}
