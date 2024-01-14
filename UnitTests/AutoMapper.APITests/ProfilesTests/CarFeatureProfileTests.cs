using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.CarFeature;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace UnitTests.AutoMapper.APITests.ProfilesTests;
public sealed class CarFeatureProfileTests
{
    public CarFeatureProfileTests()
    {
        AutoMapperFactory.Inicialize();    
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var carFeatureSaveRequest = CarFeatureBuilder.NewObject().SaveRequestBuild();

        // A
        var carFeatureResult = carFeatureSaveRequest.MapTo<CarFeatureSaveRequest, CarFeature>();

        // A
        Assert.Equal(carFeatureResult.Name, carFeatureSaveRequest.Name);
        Assert.Equal(carFeatureResult.IsAvailable, carFeatureSaveRequest.IsAvailable);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var carFeature = CarFeatureBuilder.NewObject().DomainBuild();

        // A
        var carFeatureResponseResult = carFeature.MapTo<CarFeature, CarFeatureResponse>();

        // A
        Assert.Equal(carFeatureResponseResult.Id, carFeature.Id);
        Assert.Equal(carFeatureResponseResult.Name, carFeature.Name);
        Assert.Equal(carFeatureResponseResult.IsAvailable, carFeature.IsAvailable);
    }
}
