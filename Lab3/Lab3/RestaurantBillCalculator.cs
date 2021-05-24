using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            int foodCount = 5;
            double[] foodCost = new double[foodCount];
            double totalCost = 0;
            double tax;
            double tip;

            for (int foodIndex = 0; foodIndex < foodCount; foodIndex++)
            {
                foodCost[foodIndex] = double.Parse(input.ReadLine());
                totalCost += foodCost[foodIndex]; // 이 부분 아래에 for문을 한번 더 써서 실행했는데, 쓸데없이 여러번 써서 병합
            }

            tax = totalCost * 0.05;
            totalCost += tax; // 음식 값 + 세금

            double tipPercent = double.Parse(input.ReadLine());
            tip = totalCost * tipPercent / 100;
            totalCost += tip; // 음식 값 + 세금 + 팁
            totalCost = System.Math.Round(totalCost, 2);
            return totalCost;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            double individualCost;
            uint payerCount = uint.Parse(input.ReadLine());

            individualCost = totalCost / payerCount;

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