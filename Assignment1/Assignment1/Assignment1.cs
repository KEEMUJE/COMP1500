using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            int[] integerArrays = new int[5];

            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                integerArrays[arrayNumbers] = int.Parse(input.ReadLine());
            }

            output.WriteLine("{0,14}{1,14}{2,14}", "oct", "dec", "hex");

            for (int outputNumbers = 0; outputNumbers < 5; outputNumbers++)
            {
                // COMP1500 문자열 강의, 레퍼런스 String.Format 메서드 참고하기.
                output.Write("{0, 14}", System.Convert.ToString(integerArrays[outputNumbers], 8));
                output.Write("{0, 14}", System.Convert.ToString(integerArrays[outputNumbers], 10));
                output.Write("{0, 14}", System.Convert.ToString(integerArrays[outputNumbers], 16) + "\n");
            }
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            float[] floatArrays = new float[5];

            for (int arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
            {
                floatArrays[arrayNumbers] = float.Parse(input.ReadLine());
               
                if (arrayNumbers == 4)
                {
                    for (arrayNumbers = 0; arrayNumbers < 5; arrayNumbers++)
                    {
                        double truncateFloats = System.Math.Truncate(floatArrays[arrayNumbers] * 10000) / 10000;
                        output.WriteLine("{0,25}", floatArrays[arrayNumbers].ToString("f3"));
                    }
                    
                    System.Array.Sort(floatArrays);
                    double floatArraysSum = floatArrays[0] + floatArrays[1] + floatArrays[2] + floatArrays[3] + floatArrays[4];
                    output.WriteLine("{0,-11}{1,14}", "Min", floatArrays[0].ToString("f3"));
                    output.WriteLine("{0,-11}{1,14}", "Max", floatArrays[4].ToString("f3"));
                    output.WriteLine("{0,-11}{1,14}", "Sum", floatArraysSum.ToString("f3"));
                    output.WriteLine("{0,-11}{1,14}", "Average", (floatArraysSum / 5).ToString("f3"));
                }
            }
        }
    }
}