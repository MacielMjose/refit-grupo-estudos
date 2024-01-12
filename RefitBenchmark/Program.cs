// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using RefitBenchmark;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<MyRefitBenchmark>();
Console.WriteLine(summary);