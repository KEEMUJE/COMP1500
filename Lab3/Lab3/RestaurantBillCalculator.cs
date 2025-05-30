﻿using System;
using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            double totalCost = 0;

            for (int foodIndex = 0; foodIndex < 5; foodIndex++)
            {
                totalCost += double.Parse(input.ReadLine()); // 음식 값을 입력하고 바로 totalCost에 저장하며 더해감.
            }
            double tipPercent = double.Parse(input.ReadLine());

            double tax = totalCost * 0.05;
            double tip = (totalCost + tax) * tipPercent / 100;
            totalCost = Math.Round(totalCost + tax + tip, 2);

            return totalCost;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            double individualCost;
            uint payerCount = uint.Parse(input.ReadLine());

            individualCost = Math.Round(totalCost / payerCount, 2);

            return individualCost;
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            double payerCount;
            double individualCost = double.Parse(input.ReadLine());

            payerCount = Math.Ceiling(totalCost / individualCost);

            return (uint)payerCount;
        }
    }
}