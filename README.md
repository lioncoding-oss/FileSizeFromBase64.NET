[![CI](https://github.com/lioncoding-oss/FileSizeFromBase64.NET/actions/workflows/ci.yml/badge.svg)](https://github.com/lioncoding-oss/FileSizeFromBase64.NET/actions/workflows/ci.yml)  [![NuGet](https://img.shields.io/nuget/v/FileSizeFromBase64.NET.svg?label=NuGet)](https://www.nuget.org/packages/FileSizeFromBase64.NET/)



<div style="text-align:center"><img src="art/logo.png" width=140 /></div>

# FileSizeFromBase64.NET

A .NET Standard 2.1 project containing a single method to **get file size from base64 string**. The base64 string can contain MIME-type or not. Paddings are also supported in the decoding process, you can define whether the paddings rules should be applied or not.

## Installation

You can install the NuGet Package in any .NET Project: .NET, .NET Standard, .NET Core, .NET, Xamarin, Maui, ... etc.

 FileSizeFromBase64.NET can be [found here on NuGet](https://www.nuget.org/packages/FileSizeFromBase64.NET/) and can be installed by copying and pasting the following command into your Package Manager Console within Visual Studio (Tools > NuGet Package Manager > Package Manager Console).

```powershell
Install-Package FileSizeFromBase64.NET
```

Alternatively, if you're using .NET Core then you can install FileSizeFromBase64.NET via the CLI with the following command:

```powershell
dotnet add package FileSizeFromBase64.NET
```

🚀 Install the latest version for better performance

```powershell
.NET SDK 10.0.100
  [Host] : .NET 10.0.0 (10.0.0, 10.0.25.52411), Arm64 RyuJIT armv8.0-a
  v3.0.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), Arm64 RyuJIT armv8.0-a
  v2.0.1 : .NET 10.0.0 (10.0.0, 10.0.25.52411), Arm64 RyuJIT armv8.0-a
  v2.0.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), Arm64 RyuJIT armv8.0-a
  v1.0.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), Arm64 RyuJIT armv8.0-a

IterationCount=15  LaunchCount=2  WarmupCount=10
```

| Method                                  | Job    |              Mean |          Error |         StdDev |            Median |    Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 |  Allocated | Alloc Ratio |
| --------------------------------------- | ------ | ----------------: | -------------: | -------------: | ----------------: | -------: | ------: | -------: | -------: | -------: | ---------: | ----------: |
| GetFileSizeFromRawBase64String          | v3.0.0 |         0.8489 ns |      0.0122 ns |      0.0182 ns |         0.8504 ns |  -100.0% |    2.3% |        - |        - |        - |          - |          NA |
| GetFileSizeFromRawBase64String          | v2.0.1 |   268,150.1527 ns |  2,836.3664 ns |  4,245.3400 ns |   268,407.4910 ns |   -45.0% |    1.8% |        - |        - |        - |          - |          NA |
| GetFileSizeFromRawBase64String          | v2.0.0 |   287,886.9504 ns |  4,755.8080 ns |  6,971.0023 ns |   286,065.4297 ns |   -41.0% |    2.6% |        - |        - |        - |          - |          NA |
| GetFileSizeFromRawBase64String          | v1.0.0 |   487,946.5708 ns |  3,288.8085 ns |  4,610.4506 ns |   487,734.9849 ns | baseline |         |        - |        - |        - |          - |          NA |
|                                         |        |                   |                |                |                   |          |         |          |          |          |            |             |
| GetFileSizeFromMimePrefixedBase64String | v2.0.0 |         2.6145 ns |      0.0167 ns |      0.0249 ns |         2.5986 ns |  -100.0% |    2.7% |        - |        - |        - |          - |       -100% |
| GetFileSizeFromMimePrefixedBase64String | v2.0.1 |         2.8855 ns |      0.0166 ns |      0.0248 ns |         2.8952 ns |  -100.0% |    2.6% |        - |        - |        - |          - |       -100% |
| GetFileSizeFromMimePrefixedBase64String | v3.0.0 |         3.5208 ns |      0.0216 ns |      0.0323 ns |         3.4970 ns |  -100.0% |    2.7% |        - |        - |        - |          - |       -100% |
| GetFileSizeFromMimePrefixedBase64String | v1.0.0 | 1,570,848.1272 ns | 28,294.8563 ns | 40,579.6408 ns | 1,558,949.4229 ns | baseline |         | 152.3438 | 152.3438 | 152.3438 | 10932757 B |             |

## Documentation

```csharp
using FileSizeFromBase64.NET;

var fileSize = FileSizeHelpers.GetFileSizeFromBase64String(
  string base64String,
  bool applyPaddingsRules,
  UnitsOfMeasurement unitsOfMeasurement)
```

| Parameters           | Data type |                         Description                          | Required |       Default Value       |
| :------------------- | :-------: | :----------------------------------------------------------: | -------- | :-----------------------: |
| `base64String`       |  string   |           The base64 representation  of the file.            | Yes      |                           |
| `applyPaddingsRules` |  boolean  | [Base64 - Padding](https://en.wikipedia.org/wiki/Base64#Output_padding) | No       |          `false`          |
| `unitsOfMeasurement` |   Enum    | The unit of measurement for the file size returned by the method: `UnitsOfMeasurement.Byte`, `UnitsOfMeasurement.KiloByte`, `UnitsOfMeasurement.MegaByte` | No       | `UnitsOfMeasurement.Byte` |

## Usage

```csharp
using FileSizeFromBase64.NET;

// File hello-world.txt => Size = 13 Bytes, Content: Hello world !
var base64String = "data:text/plain;base64,SGVsbG8gd29ybGQgIQ==";

var fileSize = FileSizeHelpers.GetFileSizeFromBase64String(base64String, true);
Console.WriteLine($"File size: {fileSize}");
    
var fileSizeInKB = FileSizeHelpers.GetFileSizeFromBase64String(base64String, true, UnitsOfMeasurement.KiloByte);

var fileSizeInMB = FileSizeHelpers.GetFileSizeFromBase64String(base64String, true, UnitsOfMeasurement.MegaByte);
```



## Created by: Laurent Egbakou

- LinkedIn: [Laurent Egbakou](https://www.linkedin.com/in/laurentegbakou/)
- Twitter: [@lioncoding](https://twitter.com/lioncoding)

## License

The MIT License (MIT) see the [License file](https://github.com/lioncoding-oss/FileSizeFromBase64.NET/blob/main/LICENSE)

## Contribution

Feel free to create issues and PRs 😃
