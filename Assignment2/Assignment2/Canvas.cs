using System;

namespace Assignment2
{
    public static class Canvas
    {
        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            width += 4;
            height += 4;

            char[,] canvas = new char[width, height];

            if (width == 0 || height == 0)
            {
                Array.Clear(canvas, 0, canvas.Length);
                return canvas;
            }

            if (shape == EShape.Rectangle)
            {
                PrintTop(width);

                for (int i = 0; i < height -4; i++)
                {
                    Console.Write('|');
                    Console.Write(' ');
                    for (int j = 0; j < width - 4; j++)
                    {
                        Console.Write('*');
                    }
                    Console.Write(' ');
                    Console.Write("|\n");
                }

                PrintLower(width);

                return canvas;
            }

            if (shape == EShape.IsoscelesRightTriangle && width == height)
            {
                PrintTop(width);

                for (int i = 0; i < height; i++)
                {
                    Console.Write('|');
                    Console.Write(' ');

                    for (int j = 0; j < width; j++)
                    {
                        canvas[j, j] = '*';
                    }

                    Console.Write(' ');
                    Console.Write("|\n");
                }

                PrintLower(width);

                return canvas;
            }

            else
            {
                Array.Clear(canvas, 0, canvas.Length);
                return canvas;
            }
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {
            return false;
        }

        public static void PrintTop(uint width)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write('-');
            }

            Console.Write("\n|");

            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(' ');
            }

            Console.Write("|\n");
        }

        public static void PrintLower(uint width)
        {
            Console.Write("\n|");

            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(' ');
            }

            Console.Write("|\n");

            for (int i = 0; i < width; i++)
            {
                Console.Write('-');
            }
        }
    }
}