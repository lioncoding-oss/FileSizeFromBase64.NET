﻿using FileSizeFromBase64.NET;

// 1,116,942 bytes = 1.06 MB

var sizeInMB = FileSizeHelpers.GetFileSizeFromBase64String(base64String, false, UnitsOfMeasurement.MegaByte);
Console.WriteLine($"FileSize : {sizeInMB}");