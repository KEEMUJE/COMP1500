using System;

namespace Assignment2
{
    public static class Canvas
    {
        static void PrintDrawingPaper(char[,] outline, uint width, uint height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    outline[0, j] = '-';
                    outline[height - 1, j] = '-';

                    if (i > 0 && i < height - 1)
                    {
                        outline[i, j] = ' ';
                        outline[i, 0] = '|';
                        outline[i, width - 1] = '|';
                    }
                }
            }
        }

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

            if (shape == EShape.Rectangle) // 사각형
            {
                PrintDrawingPaper(canvas, finalWidth, finalHeight);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        canvas[i + 2, j + 2] = '*';
                    }
                }

                return canvas;
            }

            if (shape == EShape.IsoscelesRightTriangle) // 직각 이등변 삼각형
            {
                if (width == height)
                {
                    PrintDrawingPaper(canvas, finalWidth, finalHeight);

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
                    PrintDrawingPaper(canvas, finalWidth, finalHeight);

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
                    PrintDrawingPaper(canvas, finalWidth, finalHeight);

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
            uint width = (uint)canvas.GetLength(1);
            uint height = (uint)canvas.GetLength(0);
            char[,] canvas2 = new char[height, width];

            if (width == 0 || height == 0)
            {
                return false;
            }

            canvas2 = Draw(width - 4, height - 4, shape);

            if (shape == EShape.Rectangle && width == 0 || height == 0 ||
                shape == EShape.IsoscelesRightTriangle && width != height ||
                shape == EShape.IsoscelesTriangle && width - 4 != (height - 4) * 2 - 1 ||
                shape == EShape.Circle && (width != height || width % 2 == 0))
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

            return true;
        }
    }
}