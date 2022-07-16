using BenchmarkDotNet.Attributes;
using FileSizeFromBase64.NET;

namespace FileSizeFromBase64.Benchmarks;

[MediumRunJob]
[MemoryDiagnoser]
public class FileSizeHelpersBenchmark
{
    private readonly string _base64;
    
    public FileSizeHelpersBenchmark()
    {
        _base64 = File.ReadAllText("data.txt");
    }
    
    [Benchmark]
    public double  GetFileSizeFromBase64StringV1() => FileSizeHelpersV1
        .GetFileSizeFromBase64String(_base64);
    
    [Benchmark]
    public double  GetFileSizeFromBase64StringV2() => FileSizeHelpers
        .GetFileSizeFromBase64String(_base64);
}