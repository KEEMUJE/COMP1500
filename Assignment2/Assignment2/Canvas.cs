using System;
using System.Diagnostics;

namespace Assignment2
{
    public static class Canvas
    {
        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            char[,] canvas = new char[height + 4, width + 4];

            if (shape == EShape.Rectangle && width == 0 || height == 0 ||
                shape == EShape.IsoscelesRightTriangle && width != height ||
                shape == EShape.IsoscelesTriangle && width != height * 2 - 1 ||
                shape == EShape.Circle && (width != height || width % 2 == 0))
            {
                return new char[0, 0];
            }

            for (int i = 1; i < height + 3; i++)
            {
                for (int j = 0; j < width + 4; j++)
                {
                    canvas[0, j] = '-';
                    canvas[height + 3, j] = '-';
                    canvas[i, j] = ' ';
                    canvas[i, 0] = '|';
                    canvas[i, width + 3] = '|';
                }
            }

            switch (shape)
            {
                case EShape.Rectangle:
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            canvas[i + 2, j + 2] = '*';
                        }
                    }
                    return canvas;

                case EShape.IsoscelesRightTriangle:
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < i + 1; j++)
                        {
                            canvas[i + 2, j + 2] = '*';
                        }
                    }
                    return canvas;

                case EShape.IsoscelesTriangle:
                    for (uint i = 0; i < height; i++)
                    {
                        for (uint j = 0; j < width - (2 * i); j++)
                        {
                            canvas[height + 1 - i, 2 + j + i] = '*';
                        }
                    }
                    return canvas;

                case EShape.Circle:
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
                    Debug.Assert(false);
                    break;
            }

            return canvas;
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {   
            uint width = (uint)canvas.GetLength(1);
            uint height = (uint)canvas.GetLength(0);

            if (canvas.Length == 0)
            {
                return false;
            }

            char[,] checkCanvas = Draw(width - 4, height - 4, shape);

            if (checkCanvas.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (canvas[i, j] != checkCanvas[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}