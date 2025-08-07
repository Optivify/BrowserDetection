using BenchmarkDotNet.Running;
using Optivify.DeviceDetector.Benchmark;

var run = BenchmarkRunner.Run<DetectionServiceBenchmarks>();
Console.WriteLine($"Benchmark done in: {run.TotalTime.TotalMilliseconds}ms.");
Console.ReadLine();