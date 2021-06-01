using System.Diagnostics;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_DAYS = 15;

            uint[] usersPerDay = new uint[NUMBER_OF_DAYS] { 0, 2, 7, 10, 24, 46, 99, 100, 104, 334, 666, 1000, 1022, 4382, 6678 };
            double[] revenuePerDay = new double[NUMBER_OF_DAYS] { 0, 1.00, 3.50, 5.00, 49.80, 120.20, 289.80, 293.00, 489.00, 25214.00, 107550.00, 245993.00, 245998.50, 246838.50, 247412.50 };

            bool bFixed = Lab5.TryFixData(usersPerDay, revenuePerDay);
            Debug.Assert(!bFixed);

            revenuePerDay[0] = 10000.2;
            revenuePerDay[6] = 156;
            revenuePerDay[11] = 45628.34;

            bFixed = Lab5.TryFixData(usersPerDay, revenuePerDay);
            Debug.Assert(bFixed);

            double[] revenuePerDayMismaching = new double[NUMBER_OF_DAYS - 1] { 0, 1.00, 3.50, 5.00, 49.80, 120.20, 289.80, 293.00, 489.00, 25214.00, 107550.00, 245993.00, 245998.50, 246838.50 };

            bFixed = Lab5.TryFixData(usersPerDay, revenuePerDayMismaching);
            Debug.Assert(!bFixed);

            uint[] usersPerDayZeroLength = new uint[0];
            double[] revenuePerDayZeroLength = new double[0];

            bFixed = Lab5.TryFixData(usersPerDayZeroLength, revenuePerDay);
            Debug.Assert(!bFixed);

            bFixed = Lab5.TryFixData(usersPerDay, revenuePerDayZeroLength);
            Debug.Assert(!bFixed);
            bFixed = Lab5.TryFixData(usersPerDayZeroLength, revenuePerDayZeroLength);
            Debug.Assert(!bFixed);

            int numInvalidEntries = Lab5.GetInvalidEntryCount(usersPerDay, revenuePerDay);
            Debug.Assert(0 == numInvalidEntries);

            revenuePerDay[0] = 10000.2;
            revenuePerDay[6] = 156;
            revenuePerDay[11] = 45628.34;

            numInvalidEntries = Lab5.GetInvalidEntryCount(usersPerDay, revenuePerDay);
            Debug.Assert(3 == numInvalidEntries);

            numInvalidEntries = Lab5.GetInvalidEntryCount(usersPerDay, revenuePerDayMismaching);
            Debug.Assert(-1 == numInvalidEntries);

            numInvalidEntries = Lab5.GetInvalidEntryCount(usersPerDayZeroLength, revenuePerDayZeroLength);
            Debug.Assert(0 == numInvalidEntries);

            Lab5.TryFixData(usersPerDay, revenuePerDay);

            double totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDay, 0, 4);
            Debug.Assert(59.30 == totalRevenue);

            totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDay, 5, 5);
            Debug.Assert(120.20 == totalRevenue);

            totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDay, 4, 6);
            Debug.Assert(459.80 == totalRevenue);

            totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDayZeroLength, 0, 4);
            Debug.Assert(-1 == totalRevenue);

            totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDay, 4, 0);
            Debug.Assert(-1 == totalRevenue);

            totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDay, 0, NUMBER_OF_DAYS);
            Debug.Assert(-1 == totalRevenue);

            totalRevenue = Lab5.CalculateTotalRevenue(revenuePerDay, NUMBER_OF_DAYS, 0);
            Debug.Assert(-1 == totalRevenue);
        }
    }
}
