using BenchmarkDotNet.Running;
using Optivify.BrowserDetection.Benchmark;

var run = BenchmarkRunner.Run<DetectionServiceBenchmarks>();
Console.WriteLine($"Benchmark done in: {run.TotalTime.TotalMilliseconds}ms.");
Console.ReadLine();