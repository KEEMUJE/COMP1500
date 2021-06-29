namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            // array = new uint[7] { 3, 1, 4, 2, 8, 6, 0 };

            if (array.Length <= 1 || array[0] > array.Length - 1)
            {
                return false;
            }

            if (array[array[0]] == array[array.Length - 1])
            {
                return true;
            }

            for (uint i = array[0]; i < array.Length; i++)
            {
                if (array.Length - 1 < array[i + array[i]])
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}