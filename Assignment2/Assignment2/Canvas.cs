using System;

namespace Assignment2
{
    public static class Canvas
    {
        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            uint finalHeight = height + 4;
            uint finalWidth = width + 4;
            char[,] canvas = new char[finalHeight, finalWidth];

            if (height == 0 || width == 0)
            {
                Array.Clear(canvas, 0, canvas.Length);

                return canvas;
            }

            if (shape == EShape.Rectangle)
            {
                PrintTop(canvas, finalWidth);

                for (int i = 0; i < height; i++)
                {
                    canvas[i + 2, 0] = '|';
                    canvas[i + 2, 1] = ' ';

                    for (int j = 0; j < finalWidth; j++)
                    {
                        canvas[i + 2, j] = '*';
                    }

                    canvas[i + 2, width + 2] = ' ';
                    canvas[i + 2, width + 3] = '|';
                }

                PrintLow(canvas, finalWidth, finalHeight);
                
                return canvas;
            }

            else if (shape == EShape.IsoscelesRightTriangle && height == width)
            {
                PrintTop(canvas, finalWidth);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        // 여기부터 할 차례! I can do it.
                    }
                }

                PrintLow(canvas, finalWidth, finalHeight);
            }

            return canvas;
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {
            return false;
        }

        private static void PrintTop(char[,] top, uint width)
        {
            for (int i = 0; i < width; i++)
            {
                top[0, i] = '-';
            }

            top[1, 0] = '|';

            for (int i = 0; i < width - 2; i++)
            {
                top[1, i + 1] = ' ';
            }

            top[1, width - 1] = '|';
        }

        private static void PrintLow(char[,] low, uint width, uint height)
        {
            low[height - 2, 0] = '|';

            for (int i = 0; i < width - 2; i++)
            {
                low[height - 2, i + 1] = ' ';
            }

            low[height - 2, width - 1] = '|';

            for (int i = 0; i < width; i++)
            {
                low[height - 1, i] = '-';
            }
        }
    }
}