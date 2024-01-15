using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.CarFeature;
using Domain.Entities;

namespace UnitTests.TestBuilders;
public sealed class CarFeatureBuilder
{
    private readonly bool _isAvailable = true;
    private readonly string _name = "joao";

    public static CarFeatureBuilder NewObject() =>
        new();

    public CarFeature DomainBuild() =>
        new()
        {
            IsAvailable = _isAvailable,
            Id = 23,
            Name = _name
        };

    public CarFeatureSaveRequest SaveRequestBuild() =>
        new(_name,
            _isAvailable);

    public CarFeatureResponse ResponseBuild() =>
        new()
        {
            IsAvailable = _isAvailable,
            Id = 23,
            Name = _name
        };
}
