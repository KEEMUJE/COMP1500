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

            int dataCount = 1;
            byte[] values = new byte[input.Length];
            using (var reader = new BinaryReader(input))
            using (var writer = new StreamWriter(output))
            {
                reader.Read(values, 0, values.Length);

                for (int i = 1; i < values.Length; ++i)
                {
                    if (values[i - 1] == values[i])
                    {
                        ++dataCount;
                    }

                    else if (dataCount > 255)
                    {
                        writer.Write(Convert.ToString(dataCount, 16));
                        writer.Write(Convert.ToString(values[i - 1], 16));
                        dataCount = 1;
                    }

                    else if (dataCount > 16)
                    {
                        writer.Write(Convert.ToString(dataCount, 16));
                        writer.Write(Convert.ToString(values[i - 1], 16));
                        dataCount = 1;
                    }

                    else
                    {
                        writer.Write($"0{Convert.ToString(dataCount, 16)}");
                        writer.Write(Convert.ToString(values[i - 1], 16));
                        dataCount = 1;
                    }
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

            char[] values = new char[input.Length];
            using (var reader = new StreamReader(input))
            using (var writer = new BinaryWriter(output))
            {
                reader.Read(values, 0, values.Length);
                for (int i = 0; i < values.Length; ++i)
                {
                    writer.Write(Convert.ToString(values[i]));
                }
            }

            return true;
        }
    }
}