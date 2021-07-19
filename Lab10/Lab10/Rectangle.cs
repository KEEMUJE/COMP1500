using System;

public class Rectangle
{
    public Rectangle(uint width, uint height)
    {
        Width = width;
        Height = height;
    }

    public uint Width { get; private set; }
    public uint Height { get; private set; }

    public double GetPerimeter()
    {
        return Math.Round(2 * (double)(Width + Height), 3);
    }

    public double GetArea()
    {
        return Math.Round(Width * (double)Height, 3);
    }
}