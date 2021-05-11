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

            output.WriteLine("{0,10}{1,10}{2,10}", "oct", "dec", "hex");

            for (int outputNumbers = 0; outputNumbers < 5; outputNumbers++)
            {
                // COMP1500 문자열 강의, 레퍼런스 String.Format 메서드 참고하기.
                output.Write("{0, 10}", System.Convert.ToString(integerArrays[outputNumbers], 8));
                output.Write("{0, 10}", System.Convert.ToString(integerArrays[outputNumbers], 10));
                output.Write("{0, 10}", System.Convert.ToString(integerArrays[outputNumbers], 16));
                output.WriteLine("");
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

                    else
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