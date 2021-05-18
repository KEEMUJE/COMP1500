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

            for (int foodIndex = 0; foodIndex < 5; foodIndex++)
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
            totalCost = System.Math.Round(totalCost, 2);
            return totalCost;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            double individualCost = 0;
            uint payerCount = uint.Parse(input.ReadLine());

            if (payerCount < 0)
            {
                payerCount = uint.Parse(input.ReadLine());
            }

            else
            {
                individualCost = totalCost / payerCount;
            }

            individualCost = System.Math.Round(individualCost, 2);
            return individualCost;
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            double payerCount = 0;
            double individualCost = double.Parse(input.ReadLine());

            if (individualCost < 0)
            {
                individualCost = double.Parse(input.ReadLine());
            }

            else
            {
                payerCount = totalCost / individualCost;
            }

            payerCount = System.Math.Ceiling(payerCount);
            return (uint)payerCount;
        }
    }
}