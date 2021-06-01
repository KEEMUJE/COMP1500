using System;

namespace Lab5
{
    public static class Lab5
    {
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            int length = revenuePerDay.Length;
            double[] fixRevenue = new double[length];
            bool[] bArray = new bool[length];

            for (int i = 0; i < length; i++)
            {
                fixRevenue[i] = revenuePerDay[i];
            }

            for (int i = 0; i < length; i++)
            {
                if (usersPerDay[i] <= 10)
                {
                    revenuePerDay[i] = Math.Round(usersPerDay[i] / 2.0, 2);
                }
                else if (usersPerDay[i] <= 100)
                {
                    revenuePerDay[i] = Math.Round((16 * usersPerDay[i] / 5.0) - 27, 2);
                }
                else if (usersPerDay[i] <= 1000)
                {
                    revenuePerDay[i] = Math.Round((usersPerDay[i] * usersPerDay[i] / 4.0) - (2 * usersPerDay[i]) - 2007, 2);
                }
                else
                {
                    revenuePerDay[i] = Math.Round(245743 + (usersPerDay[i] / 4.0), 2);
                }


                if (fixRevenue[i] != revenuePerDay[i])
                {
                    bArray[i] = true;
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (bArray[i] == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            return -1;
        }

        public static double CalculateTotalRevenue(double[] revenuePerDay, uint start, uint end)
        {
            return 0.0;
        }
    }
}