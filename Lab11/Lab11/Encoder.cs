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

            using (var reader = new BinaryReader(input))
            using (var writer = new BinaryWriter(output))
            {
                byte dataCount = 1;
                byte[] values = new byte[input.Length];
                reader.Read(values, 0, values.Length);

                for (int i = 0; i < values.Length; ++i)
                {
                    if (i == values.Length - 1)
                    {
                        writer.Write(dataCount);
                        writer.Write(values[i]);
                        break;
                    }

                    if (dataCount == 255)
                    {
                        writer.Write(dataCount);
                        writer.Write(values[i]);
                        dataCount = 1;
                    }

                    else if (values[i] == values[i + 1])
                    {
                        ++dataCount;
                    }

                    else
                    {
                        writer.Write(dataCount);
                        writer.Write(values[i]);
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

            char[] tempChar = new char[input.Length];
            using (var reader = new StreamReader(input))
            using (var writer = new BinaryWriter(output))
            {
                reader.Read(tempChar, 0, tempChar.Length);

                char[] keys = new char[tempChar.Length / 2];
                char[] values = new char[tempChar.Length / 2];
                for (int i = 0; i < tempChar.Length; ++i)
                {
                    int keysIndex = 0;
                    int valuesIndex = 0;

                    if (i % 2 == 0)
                    {
                        keys[keysIndex++] = tempChar[i];
                    }
                    else
                    {
                        values[valuesIndex++] = tempChar[i];
                    }
                }


            }

            return true;
        }
    }
}