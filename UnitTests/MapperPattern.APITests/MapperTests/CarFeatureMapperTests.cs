using DataTransferObjects.Requests.CarFeature;
using Domain.Entities;
using MapperPattern.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MapperPattern.APITests.MapperTests;
public sealed class CarFeatureMapperTests
{
    private readonly CarFeatureMapper _carFeatureMapper;

    public CarFeatureMapperTests()
    {
        _carFeatureMapper = new CarFeatureMapper();
    }

    [Fact]
    public void SaveRequestListToDomainList_SuccessfulScenario()
    {
        // A
        var carFeatureSaveRequestList = new List<CarFeatureSaveRequest>()
        {
            CarFeatureBuilder.NewObject().SaveRequestBuild()
        };

        // A
        var carFeatureListResult = _carFeatureMapper.SaveRequestListToDomainList(carFeatureSaveRequestList);

        // A
        Assert.Equal(carFeatureListResult.Count, carFeatureSaveRequestList.Count);
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var carFeatureList = new List<CarFeature>()
        {
            CarFeatureBuilder.NewObject().DomainBuild(),
            CarFeatureBuilder.NewObject().DomainBuild()
        };

        // A
        var carFeatureResponseListResult = _carFeatureMapper.DomainListToResponseList(carFeatureList);

        // A
        Assert.Equal(carFeatureResponseListResult.Count, carFeatureList.Count);
    } 
}
