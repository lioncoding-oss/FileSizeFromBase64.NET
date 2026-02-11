namespace FileSizeFromBase64.NET.Tests;

public sealed record Base64File
{
    public required string Base64String { get; init; }

    public int Size { get; init; }

    public string? Description { get; init; }

    public bool UsePaddingsRules { get; init; }
}