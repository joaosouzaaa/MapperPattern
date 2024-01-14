using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace UnitTests.AutoMapper.APITests.ProfilesTests;
public sealed class ColorProfileTests
{
    public ColorProfileTests()
    {
        AutoMapperFactory.Inicialize();
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var colorSaveRequest = ColorBuilder.NewObject().SaveRequestBuild();

        // A
        var colorResult = colorSaveRequest.MapTo<ColorSaveRequest, Color>();

        // A
        Assert.Equal(colorResult.Name, colorSaveRequest.Name);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var color = ColorBuilder.NewObject().DomainBuild();

        // A
        var colorResponseResult = color.MapTo<Color, ColorResponse>();

        // A
        Assert.Equal(colorResponseResult.Id, color.Id);
        Assert.Equal(colorResponseResult.Name, color.Name);
    }
}
