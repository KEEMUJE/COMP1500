namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            // array = new uint[7] { 3, 1, 4, 2, 8, 6, 0 };

            if (array.Length <= 1 || array[0] == 0 || array[0] > array.Length - 1)
            {
                return false;
            }

            if (array[array[0]] == array[array.Length - 1] || (array[array[0]] == array.Length - 2 && array.Length - 2 == 1))
            {
                return true;
            }

            uint[] checkArray = new uint[array.Length - 1];

            for (int i = 0; i < checkArray.Length; i++)
            {
                checkArray[i] = array[i + 1];
            }

            if (checkArray[0] == checkArray.Length - 1)
            {
                return true;
            }

            return PlayGame(checkArray);
        }
    }
}