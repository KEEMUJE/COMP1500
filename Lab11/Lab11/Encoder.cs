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
            using (var writer = new BinaryWriter(output))
            {
                reader.Read(values, 0, values.Length);

                for (int i = 0; i < values.Length; ++i)
                {
                    if (i == values.Length - 1 && values[i - 1] == values[i])
                    {
                        writer.Write(Convert.ToChar(dataCount));
                        writer.Write(Convert.ToChar(values[i]));
                        dataCount = 1;
                    }

                    else if (i == values.Length - 1)
                    {
                        writer.Write(Convert.ToChar(dataCount));
                        writer.Write(Convert.ToChar(values[i]));
                        dataCount = 1;
                    }

                    else if (values[i] == values[i + 1])
                    {
                        ++dataCount;
                    }

                    else if (dataCount >= 255)
                    {
                        writer.Write(Convert.ToChar(dataCount));
                        writer.Write(Convert.ToChar(values[i]));
                        dataCount = 1;
                    }

                    else if (dataCount > 16)
                    {
                        writer.Write(Convert.ToChar(dataCount));
                        writer.Write(Convert.ToChar(values[i]));
                        dataCount = 1;
                    }

                    else
                    {
                        writer.Write(Convert.ToChar(dataCount));
                        writer.Write(Convert.ToChar(values[i]));
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
                
            }

            return true;
        }
    }
}