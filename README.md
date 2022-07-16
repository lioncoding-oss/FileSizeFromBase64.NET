[![CI](https://github.com/lioncoding-oss/FileSizeFromBase64.NET/actions/workflows/ci.yml/badge.svg)](https://github.com/lioncoding-oss/FileSizeFromBase64.NET/actions/workflows/ci.yml)  [![NuGet](https://img.shields.io/nuget/v/FileSizeFromBase64.NET.svg?label=NuGet)](https://www.nuget.org/packages/FileSizeFromBase64.NET/)



<div style="text-align:center"><img src="art/logo.png" width=140 /></div>

# FileSizeFromBase64.NET

A .NET Standard 2.1 project containing a single method to **get file size from base64 string**. The base64 string can contain MIME-type or not. Paddings are also supported in the decoding process, you can define whether the paddings rules should be applied or not.

## Installation

You can install the NuGet Package in any .NET Project: .NET, .NET Standard, .NET Core, .NET 5 & 6, Xamarin, Maui, ... etc.

 FileSizeFromBase64.NET can be [found here on NuGet](https://www.nuget.org/packages/FileSizeFromBase64.NET/) and can be installed by copying and pasting the following command into your Package Manager Console within Visual Studio (Tools > NuGet Package Manager > Package Manager Console).

```powershell
Install-Package FileSizeFromBase64.NET
```

Alternatively, if you're using .NET Core then you can install FileSizeFromBase64.NET via the CLI with the following command:

```powershell
dotnet add package FileSizeFromBase64.NET
```

🚀 Install the latest version for better performance

![](art\screenshots\base64_with_mime_type.png)

## Documentation

```csharp
using FileSizeFromBase64.NET;

var fileSize = FileSizeHelpers.GetFileSizeFromBase64String(string base64String, bool applyPaddingsRules, UnitsOfMeasurement unitsOfMeasurement)
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
