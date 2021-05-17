using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            double totalCost = 0; // 총 금액
            double foodTotalCost = 0; // 음식 금액
            double tax; // 세금
            uint userTip = 0; // 손님이 정하는 팁 퍼센트

            for (int foodIndex = 0; foodIndex < 5; foodIndex++)
            {
                double foodCost = double.Parse(input.ReadLine());
                foodTotalCost += foodCost;
            }
            tax = foodTotalCost * 0.05;
            userTip = uint.Parse(input.ReadLine());
            double serviceTip = (foodTotalCost + tax) * userTip / 100;
            totalCost = foodTotalCost + tax + serviceTip;
            return 0;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            double individualCost;
            uint numberOfPeople = uint.Parse(input.ReadLine());
            individualCost = totalCost / numberOfPeople;
            System.Math.Round((totalCost * 100) / 100);
            return 0;
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            double individualCost = 0;
            double wallet;

            while (true)
            {
                individualCost = double.Parse(input.ReadLine());
                if (individualCost < 0)
                {
                    individualCost = double.Parse(input.ReadLine());
                }
                else
                {
                    break;
                }
            }

            wallet = totalCost / individualCost;
            return 0;
        }
    }
}