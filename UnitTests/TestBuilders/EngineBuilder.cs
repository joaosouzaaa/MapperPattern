using DataTransferObjects.Enums;
using DataTransferObjects.Requests.Engine;
using Domain.Entities;
using Domain.Enums;

namespace UnitTests.TestBuilders;
public sealed class EngineBuilder
{
    private readonly string _description = "test";
    private readonly double _horsepower = 123;

    public static EngineBuilder NewObject() =>
        new();

    public Engine DomainBuild() =>
        new()
        {
            Description = _description,
            Horsepower = _horsepower,
            Id = 123,
            Type = EEngineType.V4
        };

    public EngineSaveRequest SaveRequestBuild() =>
        new(EEngineTypeRequest.V6,
            _horsepower,
            _description);
}
