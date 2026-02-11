# FileSizeFromBase64.NET

A .NET Standard 2.1 project containing a single method to get file size from base64 string. The base64 string can contain MIME-type or not. Paddings are also supported in the decoding process, you can define whether the paddings rules should be applied or not.
## Usage

```csharp
using FileSizeFromBase64.NET;

// File hello-world.txt => Size = 13 Bytes, Content: Hello world !
var base64String = "data:text/plain;base64,SGVsbG8gd29ybGQgIQ==";

var fileSize = FileSizeHelpers.GetFileSizeFromBase64String(base64String, true);

var fileSizeInKB = FileSizeHelpers.GetFileSizeFromBase64String(base64String, true, UnitsOfMeasurement.KiloByte);

var fileSizeInMB = FileSizeHelpers.GetFileSizeFromBase64String(base64String, true, UnitsOfMeasurement.MegaByte);
```

## Parameters

| Parameter            | Type    | Description | Required | Default |
|:---------------------|:-------:|:-----------:|:--------:|:-------:|
| `base64String`       | string  | The base64 representation of the file. | Yes | |
| `applyPaddingsRules` | bool    | [Base64 Padding](https://en.wikipedia.org/wiki/Base64#Output_padding) | No | `false` |
| `unitsOfMeasurement` | Enum    | `Byte`, `KiloByte`, or `MegaByte` | No | `Byte` |

## License

MIT — see [LICENSE](https://github.com/lioncoding-oss/FileSizeFromBase64.NET/blob/main/LICENSE)
