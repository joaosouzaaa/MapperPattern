using DataTransferObjects.Enums;

namespace DataTransferObjects.Requests.Engine;
public sealed class EngineSaveRequest
{
    public required EEngineTypeRequest EngineType { get; set; }
    public required double Horsepower { get; set; }
    public required string Description { get; set; }
}
