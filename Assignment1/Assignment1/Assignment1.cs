using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            int[] integerArrays = new int[5];
            width = 10;

            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                integerArrays[arrayNumbers] = int.Parse(input.ReadLine());
            }

            if (width > 9)
            {
                output.WriteLine($"{{0,{width}}}{{1,{width + 1}}}{{2,{width + 1}}}", "oct", "dec", "hex");

                for (int outputNumbers = 0; outputNumbers < 5; outputNumbers++)
                {
                    output.Write($"{{0, {width}}}", System.Convert.ToString(integerArrays[outputNumbers], 8));
                    output.Write($"{{0, {width + 1}}}", integerArrays[outputNumbers]);
                    output.Write($"{{0, {width + 1}}}", integerArrays[outputNumbers].ToString("X"));
                    output.WriteLine("");
                }
            }

            else if (width < 9)
            {
                width = 10;
                output.WriteLine($"{{0,{width}}}{{1,{width + 1}}}{{2,{width + 1}}}", "oct", "dec", "hex");

                for (int outputNumbers = 0; outputNumbers < 5; outputNumbers++)
                {
                    output.Write($"{{0, {width}}}", System.Convert.ToString(integerArrays[outputNumbers], 8));
                    output.Write($"{{0, {width + 1}}}", integerArrays[outputNumbers]);
                    output.Write($"{{0, {width + 1}}}", integerArrays[outputNumbers].ToString("X"));
                    output.WriteLine("");
                }
            }
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            double[] doubleArrays = new double[5];

            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                doubleArrays[arrayNumbers] = double.Parse(input.ReadLine());
               
                if (arrayNumbers == 4)
                {
                    for (arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
                    {
                        output.WriteLine("{0,25}", doubleArrays[arrayNumbers].ToString("f3"));
                    }
                    
                    System.Array.Sort(doubleArrays);
                    double doubleArraysSum = doubleArrays[0] + doubleArrays[1] + doubleArrays[2] + doubleArrays[3] + doubleArrays[4];
                    if (doubleArraysSum > 99999999999999)
                    {
                        output.WriteLine("{0,-7}{1,18}", "Min", doubleArrays[0].ToString("f3"));
                        output.WriteLine("{0,-7}{1,18}", "Max", doubleArrays[4].ToString("f3"));
                        output.WriteLine("{0,-6}{1,19}", "Sum", doubleArraysSum.ToString("f3"));
                        output.WriteLine("{0,-7}{1,18}", "Average", (doubleArraysSum / 5).ToString("f3"));
                    }

                    else if (doubleArraysSum < -9999999999999)
                    {
                        output.WriteLine("{0,-6}{1,19}", "Min", doubleArrays[0].ToString("f3"));
                        output.WriteLine("{0,-6}{1,19}", "Max", doubleArrays[4].ToString("f3"));
                        output.WriteLine("{0,-5}{1,20}", "Sum", doubleArraysSum.ToString("f3"));
                        output.WriteLine("{0,-7}{1,18}", "Average", (doubleArraysSum / 5).ToString("f3"));
                    }

                    else if (doubleArraysSum < 99999999999999)
                    {
                        output.WriteLine("{0,-7}{1,18}", "Min", doubleArrays[0].ToString("f3"));
                        output.WriteLine("{0,-7}{1,18}", "Max", doubleArrays[4].ToString("f3"));
                        output.WriteLine("{0,-7}{1,18}", "Sum", doubleArraysSum.ToString("f3"));
                        output.WriteLine("{0,-7}{1,18}", "Average", (doubleArraysSum / 5).ToString("f3"));
                    }
                }
            }
        }
    }
}