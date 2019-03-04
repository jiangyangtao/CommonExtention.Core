using System;
using System.Security.Cryptography;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// Sequential Guid Type
    /// </summary>
    public enum SequentialGuidType
    {
        /// <summary>
        /// Sequential As String
        /// </summary>
        SequentialAsString,
        /// <summary>
        /// Sequential As Binary
        /// </summary>
        SequentialAsBinary,
        /// <summary>
        /// Sequential A tEnd
        /// </summary>
        SequentialAtEnd
    }

    /// <summary>
    /// Sequential Guid Generator
    /// </summary>
    public static class SequentialGuidGenerator
    {
        private static readonly RNGCryptoServiceProvider serviceProvider = new RNGCryptoServiceProvider();

        /// <summary>
        /// Create Sequential Guid
        /// </summary>
        /// <param name="guidType"></param>
        /// <returns></returns>
        public static Guid NewSequentialGuid(SequentialGuidType guidType = SequentialGuidType.SequentialAsString)
        {
            var randomBytes = new byte[10];
            serviceProvider.GetBytes(randomBytes);

            var timestamp = DateTime.UtcNow.Ticks / 10000L;
            var timestampBytes = BitConverter.GetBytes(timestamp);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            var guidBytes = new byte[16];

            switch (guidType)
            {
                case SequentialGuidType.SequentialAsString:
                case SequentialGuidType.SequentialAsBinary:
                    Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                    Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);

                    if (guidType == SequentialGuidType.SequentialAsString && BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(guidBytes, 0, 4);
                        Array.Reverse(guidBytes, 4, 2);
                    }
                    break;

                case SequentialGuidType.SequentialAtEnd:
                    Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
                    Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                    break;
            }

            return new Guid(guidBytes);
        }
    }
}
