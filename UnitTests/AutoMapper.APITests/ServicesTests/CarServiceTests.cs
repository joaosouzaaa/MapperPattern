using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Interfaces;
using AutoMapper.API.Services;
using Domain.Entities;
using Infra.Interfaces;
using Moq;
using UnitTests.TestBuilders;
using UnitTests.TestBuilders.TestUtils;

namespace UnitTests.AutoMapper.APITests.ServicesTests;
public sealed class CarServiceTests
{
    private readonly Mock<ICarRepository> _carRepositoryMock;
    private readonly Mock<IColorFacadeService> _colorFacadeServiceMock;
    private readonly CarService _carService;

    public CarServiceTests()
    {
        _carRepositoryMock = new Mock<ICarRepository>();
        _colorFacadeServiceMock = new Mock<IColorFacadeService>();
        _carService = new CarService(_carRepositoryMock.Object, _colorFacadeServiceMock.Object);

        AutoMapperFactory.Inicialize();
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var colorIdList = new List<int>()
        {
            123,
            1
        };
        var carSaveRequest = CarBuilder.NewObject().WithColorIdList(colorIdList).SaveRequestBuild();

        var color = ColorBuilder.NewObject().DomainBuild();
        _colorFacadeServiceMock.SetupSequence(c => c.GetByIdReturnsDomainObjectAsync(It.IsAny<int>()))
            .ReturnsAsync(color)
            .ReturnsAsync(color);

        _carRepositoryMock.Setup(c => c.AddAsync(It.IsAny<Car>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _carService.AddAsync(carSaveRequest);

        // A
        _carRepositoryMock.Verify(c => c.AddAsync(It.IsAny<Car>()), Times.Once());

        Assert.True(addResult);
    }

    [Fact]
    public async Task AddAsync_ColorDoesNotExist_ReturnsFalse()
    {
        // A
        var colorIdList = new List<int>()
        {
            123,
            1
        };
        var carSaveRequest = CarBuilder.NewObject().WithColorIdList(colorIdList).SaveRequestBuild();

        var color = ColorBuilder.NewObject().DomainBuild();
        _colorFacadeServiceMock.SetupSequence(c => c.GetByIdReturnsDomainObjectAsync(It.IsAny<int>()))
            .ReturnsAsync(color)
            .Returns(Task.FromResult<Color?>(null));

        // A
        var addResult = await _carService.AddAsync(carSaveRequest);

        // A
        _carRepositoryMock.Verify(c => c.AddAsync(It.IsAny<Car>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task GetByIdAsync_SuccessfulScenario_ReturnsEntity()
    {
        // A
        var id = 123;

        var car = CarBuilder.NewObject().DomainBuild();
        _carRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>(), null))
            .ReturnsAsync(car);

        // A
        var carResponseResult = await _carService.GetByIdAsync(id);

        // A
        Assert.NotNull(carResponseResult);
    }

    [Fact]
    public async Task GetByIdWithAllRelationshipsAsync_SuccessfulScenario_ReturnsEntity()
    {
        // A
        var id = 123;

        var car = CarBuilder.NewObject().DomainBuild();
        _carRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>(), TestBuilderUtil.BuildQueryableIncludeFunc<Car>()))
            .ReturnsAsync(car);

        // A
        var carWithRelationshipsResponseResult = await _carService.GetByIdWithAllRelationshipsAsync(id);

        // A
        Assert.NotNull(carWithRelationshipsResponseResult);
    }

    [Fact]
    public async Task GetAllAsync_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        var carList = new List<Car>()
        {
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild()
        };
        _carRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(carList);

        // A
        var carResponseListResult = await _carService.GetAllAsync();

        // A
        Assert.Equal(carResponseListResult.Count, carList.Count);
    }

    [Fact]
    public async Task GetAllWithAllRelationshipsAsync_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        var carList = new List<Car>()
        {
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild()
        };
        _carRepositoryMock.Setup(c => c.GetAllAsync(TestBuilderUtil.BuildQueryableIncludeFunc<Car>()))
            .ReturnsAsync(carList);

        // A
        var carWithRelationshipsResponseListResult = await _carService.GetAllWithAllRelationshipsAsync();

        // A
        Assert.Equal(carWithRelationshipsResponseListResult.Count, carList.Count);
    }
}
