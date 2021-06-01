using System;
using System.Diagnostics;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_DAYS = 15;

            uint[] usersPerDay = new uint[NUMBER_OF_DAYS] { 0, 3, 5, 10, 11, 66, 89, 100, 101, 321, 657, 1000, 1001, 4520, 6578 };
            double[] revenuePerDay = new double[NUMBER_OF_DAYS] { 0, 1.50, 2.50, 5.00, 81.80, 184.20, 257.80, 293.00, 341.25, 23111.25, 104591.25, 245993.00, 246001.00, 246873.00, 247387.50 };

            // 1. Try Fix
            bool bFixed = Lab5.TryFixData(usersPerDay, revenuePerDay);
            Debug.Assert(true == bFixed);

            Debug.Assert(0 == revenuePerDay[0]);
            Debug.Assert(1.5 == revenuePerDay[1]);
            Debug.Assert(2.5 == revenuePerDay[2]);
            Debug.Assert(5 == revenuePerDay[3]);
            Debug.Assert(8.2 == revenuePerDay[4]);
            Debug.Assert(184.2 == revenuePerDay[5]);
            Debug.Assert(257.8 == revenuePerDay[6]);
            Debug.Assert(293 == revenuePerDay[7]);
            Debug.Assert(341.25 == revenuePerDay[8]);
            Debug.Assert(23111.25 == revenuePerDay[9]);
            Debug.Assert(104591.25 == revenuePerDay[10]);
            Debug.Assert(245993 == revenuePerDay[11]);
            Debug.Assert(245993.25 == revenuePerDay[12]);
            Debug.Assert(246873 == revenuePerDay[13]);
            Debug.Assert(247387.5 == revenuePerDay[14]);


            bFixed = Lab5.TryFixData(usersPerDay, revenuePerDay);
            Debug.Assert(false == bFixed);
        }
    }
}