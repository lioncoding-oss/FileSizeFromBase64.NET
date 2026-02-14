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
            string[] versions = [
                "1.0.0",
                "2.0.0",
                "2.0.1",
                "3.0.0"
            ];

            foreach (var version in versions)
            {
                var job = Job.MediumRun
                    .WithMsBuildArguments($"/p:FileSizeFromBase64NETVersion={version}")
                    .WithId($"v{version}");

                if (version == "1.0.0")
                {
                    job = job.WithBaseline(true);
                }

                AddJob(job);
            }

            AddDiagnoser(MemoryDiagnoser.Default);
            HideColumns(Column.Arguments);
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