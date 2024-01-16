using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Extensions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using UnitTests.TestBuilders;

namespace AutoMapper.API.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[IterationCount(10)]
public sealed class ColorProfileBenchmark
{
    [GlobalSetup]
    public static void GlobalSetup()
    {
        AutoMapperFactory.Inicialize();
    }

    [Benchmark]
    public static void SaveRequestToDomain()
    {
        var colorSaveRequest = ColorBuilder.NewObject().SaveRequestBuild();

        colorSaveRequest.MapTo<ColorSaveRequest, Color>();
    }

    [Benchmark]
    public static void DomainListToResponseList_With1Item()
    {
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild()
        };

        colorList.MapTo<List<Color>, List<ColorResponse>>();
    }

    [Benchmark]
    public static void DomainListToResponseList_With10Items()
    {
        var colorList = new List<Color>();

        const int colorListCount = 10;
        for(var i = 0; i < colorListCount; i++)
        {
            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        colorList.MapTo<List<Color>, List<ColorResponse>>();
    }

    [Benchmark]
    public static void DomainListToResponseList_With100Items()
    {
        var colorList = new List<Color>();

        const int colorListCount = 100;
        for (var i = 0; i < colorListCount; i++)
        {
            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        colorList.MapTo<List<Color>, List<ColorResponse>>();
    }
}
