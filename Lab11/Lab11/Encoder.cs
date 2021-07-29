using System;
using System.IO;

namespace Lab11
{
    public static class Encoder
    {
        public static bool TryEncode(Stream input, Stream output)
        {
            if (input.Length == 0)
            {
                return false;
            }

            int dataCount = 0;
            int index = 0;
            using (var reader = new BinaryReader(input))
            using (var writer = new BinaryWriter(output))
            {
                int n = reader.ReadByte();

                if (dataCount < 255)
                {
                    writer.Write(Convert.ToString(dataCount, 16));
                    writer.Write(Convert.ToString(n, 16));
                    dataCount = 0;
                }

                if (n == reader.ReadByte())
                {
                    ++dataCount;
                }
                else
                {
                    writer.Write(Convert.ToString(dataCount, 16));
                    writer.Write(Convert.ToString(n, 16));
                }
            }

            return true;
        }

        public static bool TryDecode(Stream input, Stream output)
        {
            if (input.Length == 0)
            {
                return false;
            }

            byte[] values = new byte[input.Length];
            using (var reader = new BinaryReader(input))
            using (var writer = new BinaryWriter(output))
            {
                int n = reader.Read(values, 0, values.Length);

                for (int i = 0; i < values.Length; ++i)
                {
                    writer.Write(Convert.ToChar(values[i]));
                }
            }

            return true;
        }
    }
}