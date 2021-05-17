using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            double[] foodCost = new double[5];
            double totalCost = 0;
            double tax;
            double tip;

            for (int foodIndex = 0; foodIndex < foodCost.Length; foodIndex++)
            {
                foodCost[foodIndex] = double.Parse(input.ReadLine());
            }

            for (int foodIndex = 0; foodIndex < 5; foodIndex++)
            {
                totalCost += foodCost[foodIndex];
            }

            tax = totalCost * 0.05;
            totalCost += tax;

            double tipPercent = double.Parse(input.ReadLine());
            tip = totalCost * tipPercent / 100;
            totalCost += tip;
            System.Math.Round(totalCost, 2);
            return 0;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            double personalCost = 0;
            uint calculatingPeople = uint.Parse(input.ReadLine());
            if (calculatingPeople < 0)
            {
                calculatingPeople = uint.Parse(input.ReadLine());
            }

            else
            {
                personalCost = totalCost / calculatingPeople;
                System.Math.Round(personalCost, 2);
            }
            return 0;
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            double personalCost = double.Parse(input.ReadLine());
            double walletCount = 0;

            if (personalCost < 0)
            {
                personalCost = double.Parse(input.ReadLine());
            }

            else
            {
                walletCount = totalCost / personalCost;
            }
            return 0;
        }
    }
}