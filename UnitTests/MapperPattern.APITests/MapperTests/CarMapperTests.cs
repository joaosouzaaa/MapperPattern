using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Requests.Engine;
using Domain.Entities;
using MapperPattern.API.Interfaces.Mappers;
using MapperPattern.API.Mappers;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.MapperPattern.APITests.MapperTests;
public sealed class CarMapperTests
{
    private readonly Mock<ICarFeatureMapper> _carFeatureMapperMock;
    private readonly Mock<IColorMapper> _colorMapperMock;
    private readonly Mock<IEngineMapper> _engineMapperMock;
    private readonly CarMapper _carMapper;

    public CarMapperTests()
    {
        _carFeatureMapperMock = new Mock<ICarFeatureMapper>();
        _colorMapperMock = new Mock<IColorMapper>();
        _engineMapperMock = new Mock<IEngineMapper>();
        _carMapper = new CarMapper(_carFeatureMapperMock.Object, _colorMapperMock.Object, _engineMapperMock.Object);
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var carSaveRequest = CarBuilder.NewObject().SaveRequestBuild();

        var carFeatureList = new List<CarFeature>()
        {
            CarFeatureBuilder.NewObject().DomainBuild(),
            CarFeatureBuilder.NewObject().DomainBuild()
        };
        _carFeatureMapperMock.Setup(c => c.SaveRequestListToDomainList(It.IsAny<List<CarFeatureSaveRequest>>()))
            .Returns(carFeatureList);

        var engine = EngineBuilder.NewObject().DomainBuild();
        _engineMapperMock.Setup(e => e.SaveRequestToDomain(It.IsAny<EngineSaveRequest>()))
            .Returns(engine);

        // A
        var carResult = _carMapper.SaveRequestToDomain(carSaveRequest);

        // A
        Assert.Equal(carResult.CarFeatures.Count, carFeatureList.Count);
        Assert.NotNull(carResult.Engine);
        Assert.Equal((ushort)carResult.FuelType, (ushort)carSaveRequest.FuelType);
        Assert.Equal(carResult.HasNavigationSystem, carSaveRequest.HasNavigationSystem);
        Assert.Equal(carResult.Model, carSaveRequest.Model);
        Assert.Equal(carResult.Price, carSaveRequest.Price);
        Assert.NotEqual(carResult.RegistrationDate, DateTime.MinValue);
        Assert.Equal(carResult.Year, carSaveRequest.Year);
        Assert.Empty(carResult.Colors);
    }
}
