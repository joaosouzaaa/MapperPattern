using MapperPattern.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MapperPattern.APITests.MapperTests;
public sealed class EngineMapperTests
{
    private readonly EngineMapper _engineMapper;

    public EngineMapperTests()
    {
        _engineMapper = new EngineMapper();
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var engineSaveRequest = EngineBuilder.NewObject().SaveRequestBuild();

        // A
        var engineResult = _engineMapper.SaveRequestToDomain(engineSaveRequest);

        // A
        Assert.Equal(engineResult.Description, engineSaveRequest.Description);
        Assert.Equal(engineResult.Horsepower, engineSaveRequest.Horsepower);
        Assert.Equal((ushort)engineResult.Type, (ushort)engineSaveRequest.Type);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var engine = EngineBuilder.NewObject().DomainBuild();

        // A
        var engineResponseResult = _engineMapper.DomainToResponse(engine);

        // A
        Assert.Equal(engineResponseResult.Description, engine.Description);
        Assert.Equal(engineResponseResult.Horsepower, engine.Horsepower);
        Assert.Equal(engineResponseResult.Id, engine.Id);
        Assert.Equal(engineResponseResult.Type, (ushort)engine.Type);
    }
}
