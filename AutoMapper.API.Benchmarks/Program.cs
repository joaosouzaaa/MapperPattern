using AutoMapper.API.Benchmarks;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<CarProfileBenchmark>();
BenchmarkRunner.Run<ColorProfileBenchmark>();
