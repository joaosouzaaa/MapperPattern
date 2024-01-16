using BenchmarkDotNet.Running;
using MapperPattern.API.Benchmarks;

BenchmarkRunner.Run<CarMapperBenchmark>();
BenchmarkRunner.Run<ColorMapperBenchmark>();
