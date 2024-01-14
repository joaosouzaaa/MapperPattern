using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using DataTransferObjects.Requests.Engine;
using DataTransferObjects.Responses.Engine;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace UnitTests.AutoMapper.APITests.ProfilesTests;
public sealed class EngineProfileTests
{
    public EngineProfileTests()
    {
        AutoMapperFactory.Inicialize();
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var engineSaveRequest = EngineBuilder.NewObject().SaveRequestBuild();

        // A
        var engineResult = engineSaveRequest.MapTo<EngineSaveRequest, Engine>();

        // A
        Assert.Equal((ushort)engineResult.Type, (ushort)engineSaveRequest.Type);
        Assert.Equal(engineResult.Horsepower, engineSaveRequest.Horsepower);
        Assert.Equal(engineResult.Description, engineSaveRequest.Description);
    }

    [Fact]
    public void DomainToResponse_SuccesfulScenario()
    {
        // A
        var engine = EngineBuilder.NewObject().DomainBuild();

        // A
        var engineResponseResult = engine.MapTo<Engine, EngineResponse>();

        // A
        Assert.Equal(engineResponseResult.Id, engine.Id);
        Assert.Equal(engineResponseResult.Type, (ushort)engine.Type);
        Assert.Equal(engineResponseResult.Horsepower, engine.Horsepower);
        Assert.Equal(engineResponseResult.Description, engine.Description);
    }
}
