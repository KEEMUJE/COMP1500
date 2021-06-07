using System;
namespace Lab6
{
    public static class Lab6
    {
        public static int[,] Rotate90Degrees(int[,] data)
        {
            int[,] rotated = new int[data.GetLength(1), data.GetLength(0)];
            int rotatedRow = 0;
            int rotatedColumn = 0;

            for (int i = data.GetLength(1) - 1; i >= 0; i--)
            {
                rotatedColumn = 0;

                for (int j = 0; j < data.GetLength(0); j++)
                {
                    rotated[rotatedRow, rotatedColumn] = data[i, j];
                    rotatedColumn++;
                }

                rotatedRow++;
            }

            return rotated;
        }

        public static int[,] TransformArray(int[,] data, EMode mode)
        {
            switch (mode)
            {
                case EMode.HorizontalMirror:
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            data[i, j] = data[i, data.GetLength(1) - 1 - j];
                        }
                    }
                    break;

                case EMode.VerticalMirror:
                    break;

                case EMode.DiagonalShift:
                    break;

                default:
                    break;
            }

            return data;
        }
    }
}
