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
                canvas = new char[0, 0];
                return canvas;
            }

            if (shape == EShape.Rectangle)
            {
                printTop(canvas, finalWidth);

                for (int i = 0; i < height; i++)
                {
                    canvas[i + 2, 0] = '|';
                    canvas[i + 2, 1] = ' ';

                    for (int j = 0; j < finalWidth - 2; j++)
                    {
                        canvas[i + 2, j + 2] = '*';
                    }

                    canvas[i + 2, width + 2] = ' ';
                    canvas[i + 2, width + 3] = '|';
                }

                printLow(canvas, finalWidth, finalHeight);

                return canvas;
            }

            if (shape == EShape.IsoscelesRightTriangle) // 직각 이등변 삼각형
            {
                if (width == height)
                {
                    printTop(canvas, finalWidth);

                    for (int i = 0; i < height; i++)
                    {
                        canvas[i + 2, 0] = '|';

                        for (int j = 0; j < finalWidth - 1; j++)
                        {
                            canvas[i + 2, j + 1] = ' ';
                        }

                        canvas[i + 2, width + 3] = '|';
                    }

                    printLow(canvas, finalWidth, finalHeight);

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < i + 1; j++)
                        {
                            canvas[i + 2, j + 2] = '*';
                        }
                    }
                }

                else
                {
                    canvas = new char[0, 0];
                }

                return canvas;
            }

            if (shape == EShape.IsoscelesTriangle) // 이등변 삼각형
            {
                if (width == height * 2 - 1)
                {
                    printTop(canvas, finalWidth);

                    for (int i = 0; i < height; i++)
                    {
                        canvas[i + 2, 0] = '|';

                        for (int j = 0; j < finalWidth - 1; j++)
                        {
                            canvas[i + 2, j + 1] = ' ';
                        }

                        canvas[i + 2, width + 3] = '|';
                    }

                    printLow(canvas, finalWidth, finalHeight);

                    for (uint i = 0; i < height; i++)
                    {
                        for (uint j = 0; j < width - (2 * i); j++)
                        {
                            canvas[height + 1 - i, 2 + j + i] = '*';
                        }
                    }
                }

                else
                {
                    canvas = new char[0, 0];
                }

                return canvas;
            }

            if (shape == EShape.Circle)
            {
                int radius = (int)(Math.Truncate(width / 2.0 * 1) / 1);

                if (width == height && width % 2 != 0)
                {
                    printTop(canvas, finalWidth);

                    for (int i = 0; i < height; i++)
                    {
                        canvas[i + 2, 0] = '|';

                        for (int j = 0; j < finalWidth - 1; j++)
                        {
                            canvas[i + 2, j + 1] = ' ';
                        }

                        canvas[i + 2, width + 3] = '|';
                    }

                    for (int i = -radius; i <= radius; i++)
                    {
                        for (int j = -radius; j <= radius; j++)
                        {
                            if (i * i + j * j <= radius * radius)
                            {
                                canvas[i + radius + 2, j + radius + 2] = '*';
                            }

                            else
                            {
                                canvas[i + radius + 2, j + radius + 2] = ' ';
                            }
                        }
                    }

                    printLow(canvas, finalWidth, finalHeight);

                }

                else
                {
                    canvas = new char[0, 0];
                }

                return canvas;
            }

            return canvas;
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {
            bool bIsEqual = true;
            uint width = (uint)canvas.GetLength(1);
            uint height = (uint)canvas.GetLength(0);
            char[,] canvas2 = new char[height, width];

            if (shape == EShape.Rectangle && width == 0 || height == 0)
            {
                return false;
            }

            else if (shape == EShape.IsoscelesRightTriangle && width != height)
            {
                return false;
            }

            else if (shape == EShape.IsoscelesTriangle && width - 4 != (height - 4) * 2 - 1)
            {
                return false;
            }

            else if (shape == EShape.Circle && (width != height || width % 2 == 0))
            {
                return false;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (canvas[i, j] != canvas2[i, j])
                    {
                        return false;
                    }
                }
            }

            if (shape == EShape.Rectangle)
            {
                return true;
            }

            else if (shape == EShape.IsoscelesRightTriangle)
            {
                return true;
            }

            else if (shape == EShape.IsoscelesTriangle)
            {
                return true;
            }

            else if (shape == EShape.Circle)
            {
                return true;
            }

            return bIsEqual;
        }

        private static void printTop(char[,] top, uint width)
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

        private static void printLow(char[,] low, uint width, uint height)
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