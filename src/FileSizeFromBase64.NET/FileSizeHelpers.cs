using System;

namespace FileSizeFromBase64.NET
{
    /// <summary>
    /// File Size Helpers class.
    /// </summary>
    public static class FileSizeHelpers
    {
        /// <summary>
        /// Calculate a file size from base64 string.
        /// </summary>
        /// <param name="base64String">The base64 string.</param>
        /// <param name="applyPaddingsRules">Indicate if the padding management is required or not. Default is false</param>
        /// <param name="unitsOfMeasurement">The unit of measure of the file size returned by the method. The default unit of measure is Byte.</param>
        /// <returns>The size of the file represented by the base64 string.</returns>
        public static double GetFileSizeFromBase64String(string base64String, bool applyPaddingsRules = false, UnitsOfMeasurement unitsOfMeasurement = UnitsOfMeasurement.Byte)
        {
            if (string.IsNullOrEmpty(base64String)) return 0d;

            ReadOnlySpan<char> base64ReadOnlySpan = base64String.AsSpan();

            // RFC 2397 https://www.rfc-editor.org/rfc/rfc2397.html data:[<mediatype>][;base64],<data>
            if (base64ReadOnlySpan.StartsWith("data:".AsSpan()))
            {
                var commaIndex = base64String.IndexOf(',');
                if (commaIndex >= 0)
                    base64ReadOnlySpan = base64ReadOnlySpan[(commaIndex + 1)..];
            }

            var base64Length = base64ReadOnlySpan.Length;

            var fileSizeInByte = Math.Ceiling((double)base64Length / 4) * 3;

            if (applyPaddingsRules && base64Length >= 2)
            {
                ReadOnlySpan<char> paddings = base64ReadOnlySpan[^2..];

                fileSizeInByte = paddings switch
                {
                    _ when paddings[0] == '=' && paddings[1] == '=' => fileSizeInByte - 2,
                    _ when paddings[1] == '=' => fileSizeInByte - 1,
                    _ => fileSizeInByte
                };
            }

            return fileSizeInByte > 0 ? fileSizeInByte / (int)unitsOfMeasurement : 0;
        }
    }
}