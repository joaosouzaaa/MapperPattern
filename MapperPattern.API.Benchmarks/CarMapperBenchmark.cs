using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace MapperPattern.API.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[IterationCount(10)]
public sealed class CarMapperBenchmark
{

    [GlobalSetup]
    public void GlobalSetup()
    {

    }
}
