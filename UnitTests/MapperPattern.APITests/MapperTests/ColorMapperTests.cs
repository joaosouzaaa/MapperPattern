using Domain.Entities;
using MapperPattern.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MapperPattern.APITests.MapperTests;
public sealed class ColorMapperTests
{
    private readonly ColorMapper _colorMapper;

    public ColorMapperTests()
    {
        _colorMapper = new ColorMapper();
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var colorSaveRequest = ColorBuilder.NewObject().SaveRequestBuild();

        // A
        var colorResult = _colorMapper.SaveRequestToDomain(colorSaveRequest);

        // A
        Assert.Equal(colorResult.Name, colorSaveRequest.Name);
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild(),
            ColorBuilder.NewObject().DomainBuild()
        };

        // A
        var colorResponseListResult = _colorMapper.DomainListToResponseList(colorList);

        // A
        Assert.Equal(colorResponseListResult.Count, colorList.Count);
    }
}
