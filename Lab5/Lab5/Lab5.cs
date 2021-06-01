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

            if (usersPerDay.Length != revenuePerDay.Length)
            {
                return false;
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
            int wrongElement = 0;
            int length = revenuePerDay.Length;
            double[] fixRevenue = new double[length];

            for (int i = 0; i < length; i++)
            {
                fixRevenue[i] = revenuePerDay[i];
            }

            for (int i = 0; i < length; i++)
            {
                if (usersPerDay[i] <= 10)
                {
                    fixRevenue[i] = Math.Round(usersPerDay[i] / 2.0, 2);
                }
                else if (usersPerDay[i] <= 100)
                {
                    fixRevenue[i] = Math.Round((16 * usersPerDay[i] / 5.0) - 27, 2);
                }
                else if (usersPerDay[i] <= 1000)
                {
                    fixRevenue[i] = Math.Round((usersPerDay[i] * usersPerDay[i] / 4.0) - (2 * usersPerDay[i]) - 2007, 2);
                }
                else
                {
                    fixRevenue[i] = Math.Round(245743 + (usersPerDay[i] / 4.0), 2);
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (fixRevenue[i] != revenuePerDay[i])
                {
                    wrongElement += 1;
                }
                if (revenuePerDay.Length != usersPerDay.Length)
                {
                    return -1;
                }
            }
            return wrongElement;
        }

        public static double CalculateTotalRevenue(double[] revenuePerDay, uint start, uint end)
        {
            double totalRevenue = 0;
            uint numberStation;

            if (start < 0 || end > 14 || revenuePerDay.Length == 0)
            {
                return -1;
            }
            else if (start > end)
            {
                numberStation = start;
                start = end;
                end = numberStation;
            }


            for (uint i = start; i < end + 1; i++)
            {
                totalRevenue += revenuePerDay[i];
            }
            return totalRevenue;
        }
    }
}