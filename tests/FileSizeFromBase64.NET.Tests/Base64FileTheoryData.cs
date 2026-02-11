using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;

namespace FileSizeFromBase64.NET.Tests;

internal sealed class Base64FileTheoryData : TheoryData<Base64File>
{
    public Base64FileTheoryData()
    {
        var json = File.ReadAllBytes("data.txt");

        var files = JsonSerializer.Deserialize<List<Base64File>>(json);

        files?.ForEach(file => Add(file));
    }
}