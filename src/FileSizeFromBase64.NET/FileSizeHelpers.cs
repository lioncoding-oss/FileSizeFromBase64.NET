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
            if (string.IsNullOrEmpty(base64String)) return 0;

            // Remove MIME-type from the base64 string if exists and get the string length
            var base64Length = base64String.Contains("base64,")  ? base64String.Split(',')[1].Length : base64String.Length;

            var fileSizeInByte = Math.Ceiling((double)base64Length / 4) * 3;

            if(applyPaddingsRules && base64Length >= 2)
             {
                var paddings = base64String[^2..];
                fileSizeInByte = paddings.Equals("==") ? fileSizeInByte - 2 : paddings[1].Equals("=") ? fileSizeInByte - 1 : fileSizeInByte;
            }

            return (fileSizeInByte > 0) ? fileSizeInByte / (int)unitsOfMeasurement : 0;
        }
    }

    /// <summary>
    /// Unit of measurement.
    /// </summary>
    public enum UnitsOfMeasurement
    {
        /// <summary>
        /// B.
        /// </summary>
        Byte = 1,
        /// <summary>
        /// KB.
        /// </summary>
        KiloByte = 1_024,
        /// <summary>
        /// MB.
        /// </summary>
        MegaByte = 1_048_576
    }
}
