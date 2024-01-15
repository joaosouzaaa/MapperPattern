using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Requests.Engine;
using DataTransferObjects.Responses.CarFeature;
using DataTransferObjects.Responses.Color;
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

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var car = CarBuilder.NewObject().DomainBuild();

        // A
        var carResponseResult = _carMapper.DomainToResponse(car);

        // A
        Assert.Equal(carResponseResult.FuelType, (ushort)car.FuelType);
        Assert.Equal(carResponseResult.HasNavigationSystem, car.HasNavigationSystem);
        Assert.Equal(carResponseResult.Id, car.Id);
        Assert.Equal(carResponseResult.Model, car.Model);
        Assert.Equal(carResponseResult.Price, car.Price);
        Assert.Equal(carResponseResult.RegistrationDate, car.RegistrationDate);
        Assert.Equal(carResponseResult.Year, car.Year);
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var carList = new List<Car>()
        {
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild()
        };

        // A
        var carResponseListResult = _carMapper.DomainListToResponseList(carList);

        // A
        Assert.Equal(carResponseListResult.Count, carList.Count);
    }

    [Fact]
    public void DomainToWithRelationshipsResponse_SuccessfulScenario()
    {
        // A
        var car = CarBuilder.NewObject().DomainBuild();

        var carFeatureResponseList = new List<CarFeatureResponse>()
        {
            CarFeatureBuilder.NewObject().ResponseBuild(),
            CarFeatureBuilder.NewObject().ResponseBuild()
        };
        _carFeatureMapperMock.Setup(c => c.DomainListToResponseList(It.IsAny<List<CarFeature>>()))
            .Returns(carFeatureResponseList);

        var colorResponseList = new List<ColorResponse>()
        {
            ColorBuilder.NewObject().ResponseBuild()
        };
        _colorMapperMock.Setup(c => c.DomainListToResponseList(It.IsAny<List<Color>>()))
            .Returns(colorResponseList);

        var engineResponse = EngineBuilder.NewObject().ResponseBuild();
        _engineMapperMock.Setup(e => e.DomainToResponse(It.IsAny<Engine>()))
            .Returns(engineResponse);

        // A
        var carWithRelationshipsResponseResult = _carMapper.DomainToWithRelationshipsResponse(car);

        // A
        Assert.Equal(carWithRelationshipsResponseResult.CarFeatures.Count, carFeatureResponseList.Count);
        Assert.Equal(carWithRelationshipsResponseResult.Colors.Count, colorResponseList.Count);
        Assert.NotNull(carWithRelationshipsResponseResult.Engine);
        Assert.Equal(carWithRelationshipsResponseResult.FuelType, (ushort)car.FuelType);
        Assert.Equal(carWithRelationshipsResponseResult.HasNavigationSystem, car.HasNavigationSystem);
        Assert.Equal(carWithRelationshipsResponseResult.Id, car.Id);
        Assert.Equal(carWithRelationshipsResponseResult.Model, car.Model);
        Assert.Equal(carWithRelationshipsResponseResult.Price, car.Price);
        Assert.Equal(carWithRelationshipsResponseResult.RegistrationDate, car.RegistrationDate);
        Assert.Equal(carWithRelationshipsResponseResult.Year, car.Year);
    }

    [Fact]
    public void DomainListToWithRelationshipsResponseList_SuccessfulScenario()
    {
        // A
        var carList = new List<Car>()
        {
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild()
        };

        var carFeatureResponseList = new List<CarFeatureResponse>()
        {
            CarFeatureBuilder.NewObject().ResponseBuild(),
            CarFeatureBuilder.NewObject().ResponseBuild()
        };
        _carFeatureMapperMock.SetupSequence(c => c.DomainListToResponseList(It.IsAny<List<CarFeature>>()))
            .Returns(carFeatureResponseList)
            .Returns(carFeatureResponseList)
            .Returns(carFeatureResponseList);

        var colorResponseList = new List<ColorResponse>()
        {
            ColorBuilder.NewObject().ResponseBuild()
        };
        _colorMapperMock.SetupSequence(c => c.DomainListToResponseList(It.IsAny<List<Color>>()))
            .Returns(colorResponseList)
            .Returns(colorResponseList)
            .Returns(colorResponseList);

        var engineResponse = EngineBuilder.NewObject().ResponseBuild();
        _engineMapperMock.SetupSequence(e => e.DomainToResponse(It.IsAny<Engine>()))
            .Returns(engineResponse)
            .Returns(engineResponse)
            .Returns(engineResponse);

        // A
        var carWithRelationshipsResponseListResult = _carMapper.DomainListToWithRelationshipsResponseList(carList);

        // A
        Assert.Equal(carWithRelationshipsResponseListResult.Count, carList.Count);
    }
}
