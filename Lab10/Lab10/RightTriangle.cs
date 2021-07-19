using System;

public class RightTriangle
{
    public RightTriangle(uint width, uint height)
    {
        Width = width;
        Height = height;
    }

    public uint Width { get; private set; }
    public uint Height { get; private set; }

    public double GetPerimeter()
    {
        double thirdSide = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));

        return Math.Round(Width + Height + thirdSide, 3);
    }

    public double GetArea()
    {
        return Math.Round(Width * (double)Height / 2, 3);
    }
}