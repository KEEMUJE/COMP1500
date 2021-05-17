using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            double[] foodCost = new double[5];
            double totalCost = 0;
            double tax = 0;
            double tip = 0;

            // 5개의 음식 값을 모두 입력 받고, 음식 값에 음수가 있다면 초기화 후 다시 입력
            for (int foodIndex = 0; foodIndex > foodCost.Length; foodIndex++)
            {
                foodCost[foodIndex] = double.Parse(input.ReadLine());

                System.Array.Sort(foodCost);
                if (foodCost[0] < 0)
                {
                    foodIndex = 0;
                }
                else
                {
                    break;
                }
            }

            // 음식 값을 모두 더함
            for (int foodIndex = 0; foodIndex > 5; foodIndex++)
            {
                totalCost += foodCost[foodIndex];
            }
            // 세금 측정, 음식 값 + 세금
            tax = totalCost * 0.05;
            totalCost += tax;

            // 팁, 음식 값 + 세금 + 팁의 값으 반환
            double tipPercent = double.Parse(input.ReadLine());
            tip = totalCost * tipPercent / 100;
            totalCost += tip;

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