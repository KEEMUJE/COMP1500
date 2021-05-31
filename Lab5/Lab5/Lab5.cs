using System;

namespace Lab5
{
    public static class Lab5
    {
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            int length = revenuePerDay.Length;
            double[] fixRevenue = new double[length];

            for (int i = 0; i < length; i++)
            {
                if (usersPerDay[i] <= 10)
                {
                    revenuePerDay[i] = usersPerDay[i] / 2.0;
                }
                else if (usersPerDay[i] <= 100)
                {
                    revenuePerDay[i] = (16 * usersPerDay[i] / 5.0) - 27;
                }
                else if (usersPerDay[i] <= 1000)
                {
                    revenuePerDay[i] = (usersPerDay[i] * usersPerDay[i] / 4.0) - (2 * usersPerDay[i]) - 2007;
                }
                else
                {
                    revenuePerDay[i] = 245743 + (usersPerDay[i] / 4.0);
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