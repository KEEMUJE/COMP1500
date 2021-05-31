using System;
using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            long[] integerArrays = new long[5];

            for (int i = 0; i < 5; i++)
            {
                integerArrays[i] = long.Parse(input.ReadLine());
            }

            width = width < 10 ? 10 : width;
            output.WriteLine($"{{0,{width}}} {{1,{width}}} {{2,{width}}}", "oct", "dec", "hex");

            for (int i = 0; i < 5; i++)
            {
                output.Write($"{{0, {width}}}", Convert.ToString(integerArrays[i], 8));
                output.Write($"{{0, {width + 1}}}", integerArrays[i]);
                output.Write($"{{0, {width + 1}}}", integerArrays[i].ToString("X"));
                output.WriteLine("");
            }
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            double[] doubleArrays = new double[5];
            double min = 0.0;
            double max = 0.0;
            double sum = 0.0;

            for (int i = 0; i < 5; i++)
            {
                doubleArrays[i] = double.Parse(input.ReadLine());
                min = min < doubleArrays[i] ? min : doubleArrays[i];
                max = max > doubleArrays[i] ? max : doubleArrays[i];
                sum += doubleArrays[i];
            }
            for (int i = 0; i < 5; i++)
            {
                output.WriteLine("{0,25}", doubleArrays[i].ToString("f3"));
            }
            double average = sum / 5.0;
            output.WriteLine("{0, -3}{1, 22:f3}", "Min", min);
            output.WriteLine("{0, -3}{1, 22:f3}", "Max", max);
            output.WriteLine("{0, -3}{1, 22:f3}", "Sum", sum);
            output.WriteLine("{0, -7}{1, 18:f3}", "Average", average);
        }
    }
}