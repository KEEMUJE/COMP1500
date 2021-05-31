using System;
using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            long[] integerArrays = new long[5];

            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                integerArrays[arrayNumbers] = long.Parse(input.ReadLine());
            }

            width = width < 10 ? 10 : width;
            output.WriteLine($"{{0,{width}}} {{1,{width}}} {{2,{width}}}", "oct", "dec", "hex");

            for (int outputNumbers = 0; outputNumbers < 5; outputNumbers++)
            {
                output.Write($"{{0, {width}}}", Convert.ToString(integerArrays[outputNumbers], 8));
                output.Write($"{{0, {width + 1}}}", integerArrays[outputNumbers]);
                output.Write($"{{0, {width + 1}}}", integerArrays[outputNumbers].ToString("X"));
                output.WriteLine("");
            }
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            double[] doubleArrays = new double[5];

            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                doubleArrays[arrayNumbers] = double.Parse(input.ReadLine());
            }
            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                output.WriteLine("{0,25}", doubleArrays[arrayNumbers].ToString("f3"));
            }

            Array.Sort(doubleArrays);
            double doubleArraysSum = doubleArrays[0] + doubleArrays[1] + doubleArrays[2] + doubleArrays[3] + doubleArrays[4];
            output.WriteLine("{0, -3}{1, 22:f3}", "Min", doubleArrays[1]);
            output.WriteLine("{0, -3}{1, 22:f3}", "Max", doubleArrays[4]);
            output.WriteLine("{0, -3}{1, 22:f3}", "Sum", doubleArraysSum);
            output.WriteLine("{0, -7}{1, 18:f3}", "Average", doubleArraysSum / 5);
        }
    }
}