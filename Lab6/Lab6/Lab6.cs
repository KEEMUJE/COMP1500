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

            for (int i = 0; i < data.GetLength(1); i++)
            {
                rotatedColumn = 0;

                for (int j = data.GetLength(0) - 1; j >= 0; j--)
                {
                    rotated[rotatedRow, rotatedColumn] = data[j, i];
                    rotatedColumn++;
                }

                rotatedRow++;
            }

            return rotated;
        }

        public static void TransformArray(int[,] data, EMode mode)
        {
            int[,] copyData = new int[data.GetLength(0), data.GetLength(1)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    copyData[i, j] = data[i, j];
                }
            }

            switch (mode)
            {
                case EMode.HorizontalMirror:
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            data[i, j] = copyData[i, data.GetLength(1) - 1 - j];
                        }
                    }
                    break;

                case EMode.VerticalMirror:
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            data[i, j] = copyData[data.GetLength(0) - 1 - i, j];
                        }
                    }
                    break;

                case EMode.DiagonalShift:
                    int dataRow = data.GetLength(0) - 1;
                    int dataColumn = data.GetLength(1) - 1;

                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            data[i, j] = copyData[dataRow, dataColumn];
                            dataColumn = j;
                        }

                        dataRow = i;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
