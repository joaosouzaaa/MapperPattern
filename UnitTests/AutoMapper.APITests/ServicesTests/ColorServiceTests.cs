using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Services;
using Domain.Entities;
using Infra.Interfaces;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.AutoMapper.APITests.ServicesTests;
public sealed class ColorServiceTests
{
    private readonly Mock<IColorRepository> _colorRepositoryMock;
    private readonly ColorService _colorService;

    public ColorServiceTests()
    {
        _colorRepositoryMock = new Mock<IColorRepository>();
        _colorService = new ColorService(_colorRepositoryMock.Object);

        AutoMapperFactory.Inicialize();
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var colorSaveRequest = ColorBuilder.NewObject().SaveRequestBuild();

        _colorRepositoryMock.Setup(c => c.AddAsync(It.IsAny<Color>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _colorService.AddAsync(colorSaveRequest);

        // A
        Assert.True(addResult);
    }

    [Fact]
    public async Task GetAllAsync_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild()
        };

        _colorRepositoryMock.Setup(c => c.GetAllAsync())
            .ReturnsAsync(colorList);

        // A
        var colorResponseListResult = await _colorService.GetAllAsync();

        // A
        Assert.Equal(colorResponseListResult.Count, colorList.Count);
    }

    [Fact]
    public async Task GetByIdReturnsDomainObjectAsync_SuccessfulScenario_ReturnsEntity()
    {
        // A
        var id = 123;

        var color = ColorBuilder.NewObject().DomainBuild();
        _colorRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(color);

        // A
        var colorResult = await _colorService.GetByIdReturnsDomainObjectAsync(id);

        // A
        Assert.NotNull(colorResult);
    }
}
