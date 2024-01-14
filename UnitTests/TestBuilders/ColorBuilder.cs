using DataTransferObjects.Requests.Color;
using Domain.Entities;

namespace UnitTests.TestBuilders;
public sealed class ColorBuilder
{
    private readonly string _name = "test";

    public static ColorBuilder NewObject() =>
        new();

    public Color DomainBuild() =>
        new()
        {
            Id = 123,
            Name = _name
        };

    public ColorSaveRequest SaveRequestBuild() =>
        new(_name);
}
