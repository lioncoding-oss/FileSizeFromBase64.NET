﻿using Shouldly;
using Xunit;

namespace FileSizeFromBase64.NET.Tests;

public class FileSizeHelpersTests
{

    [Fact]
    public void  GetFileSizeFromBase64String_Should_Return_0_If_String_Is_Null()
    {
        var size = FileSizeHelpers.GetFileSizeFromBase64String(null);
        size.ShouldBe(0);
    }

    [Theory]
    [ClassData(typeof(Base64FileTheoryData))]
    public void GetFileSizeFromBase64String_Should_Return_The_Right_Size(Base64File base64File)
    {
        var size = FileSizeHelpers.GetFileSizeFromBase64String(base64File.Base64String, base64File.UsePaddingsRules);
        size.ShouldBe(base64File.Size);
    }
}