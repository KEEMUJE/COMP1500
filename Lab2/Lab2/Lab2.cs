using System;
namespace Lab2
{
    public static class Lab2
    {
        public static int GetSum(int num1, int num2, int num3, int num4)
        {
            return num1 + num2 + num3 + num4;
        }

        public static double GetAverage(int num1, int num2, int num3, int num4)
        {
            double sum = GetSum(num1, num2, num3, num4);
            return sum / 4;
        }

        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        public static string CombineStrings(string s1, string s2)
        {
            return s1 + s2;
        }
    }
}