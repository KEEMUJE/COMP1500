using System;
using System.Diagnostics;

namespace Assignment2
{
    public static class Canvas
    {
        static void PrintDrawingPaper(char[,] outline, uint width, uint height)
        {
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    outline[0, j] = '-';
                    outline[height - 1, j] = '-';
                    outline[i, j] = ' ';
                    outline[i, 0] = '|';
                    outline[i, width - 1] = '|';
                }
            }
        }

        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            char[,] canvas = new char[height + 4, width + 4];

            if (shape == EShape.Rectangle && width == 0 || height == 0 ||
                shape == EShape.IsoscelesRightTriangle && width != height ||
                shape == EShape.IsoscelesTriangle && width != height * 2 - 1 ||
                shape == EShape.Circle && (width != height || width % 2 == 0))
            {
                canvas = new char[0, 0];
                return canvas;
            }

            switch (shape)
            {
                case EShape.Rectangle:
                    PrintDrawingPaper(canvas, width + 4, height + 4);

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            canvas[i + 2, j + 2] = '*';
                        }
                    }
                    return canvas;

                case EShape.IsoscelesRightTriangle:
                    PrintDrawingPaper(canvas, width + 4, height + 4);

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < i + 1; j++)
                        {
                            canvas[i + 2, j + 2] = '*';
                        }
                    }
                    return canvas;

                case EShape.IsoscelesTriangle:
                    PrintDrawingPaper(canvas, width + 4, height + 4);

                    for (uint i = 0; i < height; i++)
                    {
                        for (uint j = 0; j < width - (2 * i); j++)
                        {
                            canvas[height + 1 - i, 2 + j + i] = '*';
                        }
                    }
                    return canvas;

                case EShape.Circle:
                    PrintDrawingPaper(canvas, width + 4, height + 4);

                    int radius = (int)(width / 2.0);

                    for (int i = -radius; i <= radius; i++)
                    {
                        for (int j = -radius; j <= radius; j++)
                        {
                            if (i * i + j * j <= radius * radius)
                            {
                                canvas[i + radius + 2, j + radius + 2] = '*';
                            }
                        }
                    }
                    return canvas;

                default:
                    Debug.Assert(true);
                    break;
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