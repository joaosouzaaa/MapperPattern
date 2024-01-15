using MapperPattern.API.Services;
using Infra.Interfaces;
using MapperPattern.API.Interfaces.Mappers;
using Moq;
using MapperPattern.API.Interfaces.Services;
using UnitTests.TestBuilders;
using DataTransferObjects.Requests.Car;
using Domain.Entities;
using UnitTests.TestBuilders.TestUtils;
using DataTransferObjects.Responses.Car;

namespace UnitTests.MapperPattern.APITests.ServicesTests;
public sealed class CarServiceTests
{
    private readonly Mock<ICarRepository> _carRepositoryMock;
    private readonly Mock<ICarMapper> _carMapperMock;
    private readonly Mock<IColorFacadeService> _colorFacadeServiceMock;
    private readonly CarService _carService;

    public CarServiceTests()
    {
        _carRepositoryMock = new Mock<ICarRepository>();
        _carMapperMock = new Mock<ICarMapper>();
        _colorFacadeServiceMock = new Mock<IColorFacadeService>();
        _carService = new CarService(_carRepositoryMock.Object, _carMapperMock.Object, _colorFacadeServiceMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var colorIdList = new List<int>()
        {
            1,
            3,
            4
        };
        var carSaveRequest = CarBuilder.NewObject().WithColorIdList(colorIdList).SaveRequestBuild();

        var car = CarBuilder.NewObject().DomainBuild();
        _carMapperMock.Setup(c => c.SaveRequestToDomain(It.IsAny<CarSaveRequest>()))
            .Returns(car);

        var color = ColorBuilder.NewObject().DomainBuild();
        _colorFacadeServiceMock.SetupSequence(c => c.GetByIdReturnsDomainObjectAsync(It.IsAny<int>()))
            .ReturnsAsync(color)
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
            1
        };
        var carSaveRequest = CarBuilder.NewObject().WithColorIdList(colorIdList).SaveRequestBuild();

        var car = CarBuilder.NewObject().DomainBuild();
        _carMapperMock.Setup(c => c.SaveRequestToDomain(It.IsAny<CarSaveRequest>()))
            .Returns(car);

        _colorFacadeServiceMock.Setup(c => c.GetByIdReturnsDomainObjectAsync(It.IsAny<int>()))
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
        var id = 13;

        var car = CarBuilder.NewObject().DomainBuild();
        _carRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>(), null))
            .ReturnsAsync(car);

        var carResponse = CarBuilder.NewObject().ResponseBuild();
        _carMapperMock.Setup(c => c.DomainToResponse(It.IsAny<Car>()))
            .Returns(carResponse);

        // A
        var carResponseResult = await _carService.GetByIdAsync(id);

        // A
        _carMapperMock.Verify(c => c.DomainToResponse(It.IsAny<Car>()), Times.Once());

        Assert.NotNull(carResponseResult);
    }

    [Fact]
    public async Task GetByIdAsync_CarDoesNotExist_ReturnsNull()
    {
        // A
        var id = 13;

        _carRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>(), null))
            .Returns(Task.FromResult<Car?>(null));

        // A
        var carResponseResult = await _carService.GetByIdAsync(id);

        // A
        _carMapperMock.Verify(c => c.DomainToResponse(It.IsAny<Car>()), Times.Never());

        Assert.Null(carResponseResult);
    }

    [Fact]
    public async Task GetByIdWithAllRelationshipsAsync_SuccessfulScenario_ReturnsEntity()
    {
        // A
        var id = 113;

        var car = CarBuilder.NewObject().DomainBuild();
        _carRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>(), TestBuilderUtil.BuildQueryableIncludeFunc<Car>()))
            .ReturnsAsync(car);

        var carWithRelationshipsResponse = CarBuilder.NewObject().WithRelationshipsResponseBuild();
        _carMapperMock.Setup(c => c.DomainToWithRelationshipsResponse(It.IsAny<Car>()))
            .Returns(carWithRelationshipsResponse);

        // A
        var carWithRelationshipsResponseResult = await _carService.GetByIdWithAllRelationshipsAsync(id);

        // A
        _carMapperMock.Verify(c => c.DomainToWithRelationshipsResponse(It.IsAny<Car>()), Times.Once());

        Assert.NotNull(carWithRelationshipsResponseResult);
    }

    [Fact]
    public async Task GetByIdWithAllRelationshipsAsync_CarDoesNotExist_ReturnsNull()
    {
        // A
        var id = 23;

        _carRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>(), TestBuilderUtil.BuildQueryableIncludeFunc<Car>()))
            .Returns(Task.FromResult<Car?>(null));

        // A
        var carWithRelationshipsResponseResult = await _carService.GetByIdWithAllRelationshipsAsync(id);

        // A
        _carMapperMock.Verify(c => c.DomainToWithRelationshipsResponse(It.IsAny<Car>()), Times.Never());

        Assert.Null(carWithRelationshipsResponseResult);
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

        var carResponseList = new List<CarResponse>()
        {
            CarBuilder.NewObject().ResponseBuild(),
            CarBuilder.NewObject().ResponseBuild(),
            CarBuilder.NewObject().ResponseBuild()
        };
        _carMapperMock.Setup(c => c.DomainListToResponseList(It.IsAny<List<Car>>()))
            .Returns(carResponseList);

        // A
        var carResponseListResult = await _carService.GetAllAsync();

        // A
        Assert.Equal(carResponseListResult.Count, carResponseList.Count);
    }

    [Fact]
    public async Task GetAllWithRelationshipsAsync_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        var carList = new List<Car>()
        {
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild(),
            CarBuilder.NewObject().DomainBuild()
        };
        _carRepositoryMock.Setup(c => c.GetAllAsync(TestBuilderUtil.BuildQueryableIncludeFunc<Car>()))
            .ReturnsAsync(carList);

        var carWithRelationshipsResponseList = new List<CarWithRelationshipsResponse>()
        {
            CarBuilder.NewObject().WithRelationshipsResponseBuild(),
            CarBuilder.NewObject().WithRelationshipsResponseBuild(),
            CarBuilder.NewObject().WithRelationshipsResponseBuild(),
            CarBuilder.NewObject().WithRelationshipsResponseBuild(),
            CarBuilder.NewObject().WithRelationshipsResponseBuild()
        };
        _carMapperMock.Setup(c => c.DomainListToWithRelationshipsResponseList(It.IsAny<List<Car>>()))
            .Returns(carWithRelationshipsResponseList);

        // A
        var carWithRelationshipsResponseListResult = await _carService.GetAllWithAllRelationshipsAsync();

        // A
        Assert.Equal(carWithRelationshipsResponseListResult.Count, carWithRelationshipsResponseList.Count);
    }
}
