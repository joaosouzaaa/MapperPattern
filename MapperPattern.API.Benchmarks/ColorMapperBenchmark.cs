using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Domain.Entities;
using MapperPattern.API.Mappers;
using UnitTests.TestBuilders;

namespace MapperPattern.API.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[IterationCount(10)]
public class ColorMapperBenchmark
{
    private ColorMapper _colorMapper;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _colorMapper = new ColorMapper();
    }

    [Benchmark]
    public void SaveRequestToDomain()
    {
        var colorSaveRequest = ColorBuilder.NewObject().SaveRequestBuild();

        _colorMapper.SaveRequestToDomain(colorSaveRequest);
    }

    [Benchmark]
    public void DomainListToResponseList_With1Item()
    {
        var colorList = new List<Color>()
        {
            ColorBuilder.NewObject().DomainBuild()
        };

        _colorMapper.DomainListToResponseList(colorList);
    }

    [Benchmark]
    public void DomainListToResponseList_With10Items()
    {
        var colorList = new List<Color>();

        const int colorListCount = 10;
        for (var i = 0; i < colorListCount; i++)
        {
            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        _colorMapper.DomainListToResponseList(colorList);
    }

    [Benchmark]
    public void DomainListToResponseList_With100Items()
    {
        var colorList = new List<Color>();

        const int colorListCount = 100;
        for (var i = 0; i < colorListCount; i++)
        {
            var color = ColorBuilder.NewObject().DomainBuild();
            colorList.Add(color);
        }

        _colorMapper.DomainListToResponseList(colorList);
    }
}
