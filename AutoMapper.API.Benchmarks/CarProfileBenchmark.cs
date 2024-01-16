using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.Car;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace AutoMapper.API.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[IterationCount(10)]
public class CarProfileBenchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        AutoMapperFactory.Inicialize();
    }

    [Benchmark]
    public void SaveRequestToDomain_CarFeatureListWith1Item()
    {
        var carFeatureSaveRequestList = new List<CarFeatureSaveRequest>()
        {
            CarFeatureBuilder.NewObject().SaveRequestBuild()
        };
        var carSaveRequest = CarBuilder.NewObject().WithCarFeatureSaveRequestList(carFeatureSaveRequestList).SaveRequestBuild();

        carSaveRequest.MapTo<CarSaveRequest, Car>();
    }

    [Benchmark]
    public void SaveRequestToDomain_CarFeatureListWith10Items()
    {
        var carFeatureSaveRequestList = new List<CarFeatureSaveRequest>();

        const int carFeatureSaveRequestListCount = 10;
        for (var i = 0; i < carFeatureSaveRequestListCount; i++)
        {
            var carFeatureSaveRequest = CarFeatureBuilder.NewObject().SaveRequestBuild();
            carFeatureSaveRequestList.Add(carFeatureSaveRequest);
        }

        var carSaveRequest = CarBuilder.NewObject().WithCarFeatureSaveRequestList(carFeatureSaveRequestList).SaveRequestBuild();

        carSaveRequest.MapTo<CarSaveRequest, Car>();
    }

    [Benchmark]
    public void SaveRequestToDomain_CarFeatureListWith100Items()
    {
        var carFeatureSaveRequestList = new List<CarFeatureSaveRequest>();

        const int carFeatureSaveRequestListCount = 100;
        for (var i = 0; i < carFeatureSaveRequestListCount; i++)
        {
            var carFeatureSaveRequest = CarFeatureBuilder.NewObject().SaveRequestBuild();
            carFeatureSaveRequestList.Add(carFeatureSaveRequest);
        }

        var carSaveRequest = CarBuilder.NewObject().WithCarFeatureSaveRequestList(carFeatureSaveRequestList).SaveRequestBuild();

        carSaveRequest.MapTo<CarSaveRequest, Car>();
    }

    [Benchmark]
    public void DomainToResponse()
    {
        var car = CarBuilder.NewObject().DomainBuild();

        car.MapTo<Car, CarResponse>();
    }

    [Benchmark]
    public void DomainToWithRelationshipsResponse_CollectionsWith1Item()
    {
        var carFeatureList = new List<CarFeature>()
        {
            CarFeatureBuilder.NewObject().DomainBuild()
        };
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild()
        };
        var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();

        car.MapTo<Car, CarWithRelationshipsResponse>();
    }

    [Benchmark]
    public void DomainToWithRelationshipsResponse_CollectionsWith10Items()
    {
        var carFeatureList = new List<CarFeature>();
        var colorList = new List<Color>();

        const int collectionsCount = 10;
        for (var i = 0; i < collectionsCount; i++)
        {
            var carFeature = CarFeatureBuilder.NewObject().DomainBuild();
            carFeatureList.Add(carFeature);

            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();

        car.MapTo<Car, CarWithRelationshipsResponse>();
    }

    [Benchmark]
    public void DomainToWithRelationshipsResponse_CollectionsWith100Items()
    {
        var carFeatureList = new List<CarFeature>();
        var colorList = new List<Color>();

        const int collectionsCount = 100;
        for (var i = 0; i < collectionsCount; i++)
        {
            var carFeature = CarFeatureBuilder.NewObject().DomainBuild();
            carFeatureList.Add(carFeature);

            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();

        car.MapTo<Car, CarWithRelationshipsResponse>();
    }

    [Benchmark]
    public void DomainListToResponseList_With10Items()
    {
        var carList = new List<Car>();

        const int carListCount = 10;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarResponse>>();
    }

    [Benchmark]
    public void DomainListToResponseList_With100Items()
    {
        var carList = new List<Car>();

        const int carListCount = 100;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarResponse>>();
    }

    [Benchmark]
    public void DomainListToWithRelationshipsList_CollectionsWith1Item_With10Items()
    {
        var carList = new List<Car>();

        var carFeatureList = new List<CarFeature>()
        {
            CarFeatureBuilder.NewObject().DomainBuild()
        };
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild()
        };

        const int carListCount = 10;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }

    [Benchmark]
    public void DomainListToWithRelationshipsList_CollectionsWith10Items_With10Items()
    {
        var carList = new List<Car>();
        var carFeatureList = new List<CarFeature>();
        var colorList = new List<Color>();

        const int collectionsCount = 10;
        for (var i = 0; i < collectionsCount; i++)
        {
            var carFeature = CarFeatureBuilder.NewObject().DomainBuild();
            carFeatureList.Add(carFeature);

            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        const int carListCount = 10;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }

    [Benchmark]
    public void DomainListToWithRelationshipsList_CollectionsWith100Items_With10Items()
    {
        var carList = new List<Car>();
        var carFeatureList = new List<CarFeature>();
        var colorList = new List<Color>();

        const int collectionsCount = 100;
        for (var i = 0; i < collectionsCount; i++)
        {
            var carFeature = CarFeatureBuilder.NewObject().DomainBuild();
            carFeatureList.Add(carFeature);

            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        const int carListCount = 10;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }

    [Benchmark]
    public void DomainListToWithRelationshipsList_CollectionsWith1Item_With100Items()
    {
        var carList = new List<Car>();

        var carFeatureList = new List<CarFeature>()
        {
            CarFeatureBuilder.NewObject().DomainBuild()
        };
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild()
        };

        const int carListCount = 100;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }

    [Benchmark]
    public void DomainListToWithRelationshipsList_CollectionsWith10Items_With100Items()
    {
        var carList = new List<Car>();
        var carFeatureList = new List<CarFeature>();
        var colorList = new List<Color>();

        const int collectionsCount = 10;
        for (var i = 0; i < collectionsCount; i++)
        {
            var carFeature = CarFeatureBuilder.NewObject().DomainBuild();
            carFeatureList.Add(carFeature);

            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        const int carListCount = 100;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }

    [Benchmark]
    public void DomainListToWithRelationshipsList_CollectionsWith100Items_With100Items()
    {
        var carList = new List<Car>();
        var carFeatureList = new List<CarFeature>();
        var colorList = new List<Color>();

        const int collectionsCount = 100;
        for (var i = 0; i < collectionsCount; i++)
        {
            var carFeature = CarFeatureBuilder.NewObject().DomainBuild();
            carFeatureList.Add(carFeature);

            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        const int carListCount = 100;
        for (var i = 0; i < carListCount; i++)
        {
            var car = CarBuilder.NewObject().WithCarFeatureList(carFeatureList).WithColorList(colorList).DomainBuild();
            carList.Add(car);
        }

        carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }
}
