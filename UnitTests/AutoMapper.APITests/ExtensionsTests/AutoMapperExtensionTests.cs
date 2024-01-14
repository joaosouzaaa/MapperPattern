using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace UnitTests.AutoMapper.APITests.ExtensionsTests;
public sealed class AutoMapperExtensionTests
{
    public AutoMapperExtensionTests()
    {
        AutoMapperFactory.Inicialize();    
    }

    [Fact]
    public void MapTo_SuccessfulScenario()
    {
        // A
        var color = ColorBuilder.NewObject().DomainBuild();

        // A
        var colorResponse = color.MapTo<Color, ColorResponse>();

        // A
        Assert.Equal(typeof(ColorResponse), colorResponse.GetType());
    }
}
