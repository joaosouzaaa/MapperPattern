using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.Car;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace UnitTests.AutoMapper.APITests.ProfilesTests;
public sealed class CarProfileTests
{
    public CarProfileTests()
    {
        AutoMapperFactory.Inicialize();
    }

    [Fact]
    public void SaveRequestToDomain_SuccessfulScenario()
    {
        // A
        var carFeatureSaveRequestList = new List<CarFeatureSaveRequest>()
        {
            CarFeatureBuilder.NewObject().SaveRequestBuild()
        };
        var carSaveRequest = CarBuilder.NewObject().WithCarFeatureSaveRequestList(carFeatureSaveRequestList).SaveRequestBuild();

        // A
        var carResult = carSaveRequest.MapTo<CarSaveRequest, Car>();

        // A
        Assert.Equal(carResult.Model, carSaveRequest.Model);
        Assert.Equal(carResult.Year, carSaveRequest.Year);
        Assert.Equal(carResult.Price, carSaveRequest.Price);
        Assert.Equal((ushort)carResult.FuelType, (ushort)carSaveRequest.FuelType);
        Assert.Equal(carResult.HasNavigationSystem, carSaveRequest.HasNavigationSystem);
        Assert.NotNull(carResult.Engine);
        Assert.Equal(carResult.CarFeatures.Count, carSaveRequest.CarFeatures.Count);
        Assert.Empty(carResult.Colors);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var car = CarBuilder.NewObject().DomainBuild();

        // A
        var carResponseResult = car.MapTo<Car, CarResponse>();

        // A
        Assert.Equal(carResponseResult.Id, car.Id);
        Assert.Equal(carResponseResult.Model, car.Model);
        Assert.Equal(carResponseResult.Year, car.Year);
        Assert.Equal(carResponseResult.Price, car.Price);
        Assert.Equal(carResponseResult.RegistrationDate, car.RegistrationDate);
        Assert.Equal(carResponseResult.FuelType, (ushort)car.FuelType);
        Assert.Equal(carResponseResult.HasNavigationSystem, car.HasNavigationSystem);
    }

    [Fact]
    public void DomainToWithRelationshipsResponse_SuccessfulScenario()
    {
        // A
        var carFeatureList = new List<CarFeature>()
        {
            CarFeatureBuilder.NewObject().DomainBuild(),
            CarFeatureBuilder.NewObject().DomainBuild(),
            CarFeatureBuilder.NewObject().DomainBuild()
        };
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild(),
            ColorBuilder.NewObject().DomainBuild()
        };
        var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();

        // A
        var carWithRelationshipsResponseResult = car.MapTo<Car, CarWithRelationshipsResponse>();

        // A
        Assert.Equal(carWithRelationshipsResponseResult.Id, car.Id);
        Assert.Equal(carWithRelationshipsResponseResult.Model, car.Model);
        Assert.Equal(carWithRelationshipsResponseResult.Year, car.Year);
        Assert.Equal(carWithRelationshipsResponseResult.Price, car.Price);
        Assert.Equal(carWithRelationshipsResponseResult.RegistrationDate, car.RegistrationDate);
        Assert.Equal(carWithRelationshipsResponseResult.FuelType, (ushort)car.FuelType);
        Assert.Equal(carWithRelationshipsResponseResult.HasNavigationSystem, car.HasNavigationSystem);
        Assert.NotNull(carWithRelationshipsResponseResult.Engine);
        Assert.Equal(carWithRelationshipsResponseResult.CarFeatures.Count, car.CarFeatures.Count);
        Assert.Equal(carWithRelationshipsResponseResult.Colors.Count, car.Colors.Count);
    }
}
