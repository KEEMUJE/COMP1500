using System;

namespace Lab5
{
    public static class Lab5
    {
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            double fixRevenue;
            bool bIsFixed = false;

            if (usersPerDay.Length != revenuePerDay.Length)
            {
                return false;
            }

            for (int i = 0; i < usersPerDay.Length; i++)
            {
                if (usersPerDay[i] <= 10)
                {
                    fixRevenue = Math.Round(usersPerDay[i] / 2.0, 2);
                }

                else if (usersPerDay[i] <= 100)
                {
                    fixRevenue = Math.Round(16 * usersPerDay[i] / 5.0 - 27, 2);
                }

                else if (usersPerDay[i] <= 1000)
                {
                    fixRevenue = Math.Round(usersPerDay[i] * usersPerDay[i] / 4.0 - 2 * usersPerDay[i] - 2007, 2);
                }

                else
                {
                    fixRevenue = Math.Round(245743 + usersPerDay[i] / 4.0, 2);
                }

                if (revenuePerDay[i] != fixRevenue)
                {
                    bIsFixed = true;
                    revenuePerDay[i] = fixRevenue;
                }
            }

            return bIsFixed;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            int wrongElement = 0;
            double fixRevenue;

            if (usersPerDay.Length != revenuePerDay.Length)
            {
                return -1;
            }

            for (int i = 0; i < usersPerDay.Length; i++)
            {
                if (usersPerDay[i] <= 10)
                {
                    fixRevenue = Math.Round(usersPerDay[i] / 2.0, 2);
                }

                else if (usersPerDay[i] <= 100)
                {
                    fixRevenue = Math.Round(16 * usersPerDay[i] / 5.0 - 27, 2);
                }

                else if (usersPerDay[i] <= 1000)
                {
                    fixRevenue = Math.Round(usersPerDay[i] * usersPerDay[i] / 4.0 - 2 * usersPerDay[i] - 2007, 2);
                }

                else
                {
                    fixRevenue = Math.Round(245743 + usersPerDay[i] / 4.0, 2);
                }

                if (fixRevenue != revenuePerDay[i])
                {
                    wrongElement += 1;
                }
            }

            return wrongElement;
        }

        public static double CalculateTotalRevenue(double[] revenuePerDay, uint start, uint end)
        {
            double totalRevenue = 0;

            if (revenuePerDay.Length == 0 || start < 0 || end >= revenuePerDay.Length || start > end)
            {
                return -1;
            }

            for (uint i = start; i < end + 1; i++)
            {
                totalRevenue += revenuePerDay[i];
            }

            return totalRevenue;
        }
    }
}