using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using FileSizeFromBase64.NET;

namespace FileSizeFromBase64.Benchmarks;

[Config(typeof(Config))]
public class FileSizeHelpersBenchmark
{
    private sealed class Config : ManualConfig
    {
        public Config()
        {
            var baseJob = Job.MediumRun;

            AddJob(baseJob.WithNuGet("FileSizeFromBase64.NET", "1.0.0").WithId("v1.0.0").WithBaseline(true));
            AddJob(baseJob.WithNuGet("FileSizeFromBase64.NET", "2.0.0").WithId("v2.0.0"));

            AddDiagnoser(MemoryDiagnoser.Default);
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
            Orderer = new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest);
        }
    }

    private string _rawBase64 = null!;
    private string _mimeBase64 = null!;

    [GlobalSetup]
    public void Setup()
    {
        _rawBase64 = File.ReadAllText("data.txt");
        _mimeBase64 = "data:text/plain;base64," + _rawBase64;
    }

    [Benchmark]
    public double GetFileSizeFromRawBase64String()
        => FileSizeHelpers.GetFileSizeFromBase64String(_rawBase64);

    [Benchmark]
    public double GetFileSizeFromMimePrefixedBase64String()
        => FileSizeHelpers.GetFileSizeFromBase64String(_mimeBase64);
}