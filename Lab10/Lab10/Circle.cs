using System;

namespace Lab10
{
    public class Circle
    {
        const float PI = 3.14159265359f;

        public Circle(uint radius)
        {
            Radius = radius;
            Diameter = radius * 2;
        }

        public uint Radius { get; private set; }
        public uint Diameter { get; private set; }

        public double GetCircumference()
        {
            return Math.Round(Diameter * PI, 3);
        }

        public double GetArea()
        {
            return Math.Round(Math.Pow(Radius, 2) * PI, 3);
        }
    }
}