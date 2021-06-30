namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            if (array.Length <= 1 || array[0] > array.Length - 1 || array[0] == 0)
            {
                return false;
            }

            if (array[array[0]] == array[array.Length - 1] || (array[array.Length - 2] == 1 && array[0] == array.Length - 2))
            {
                return true;
            }

            uint[] checkArray = new uint[array.Length - 1];

            /*
            for (int i = 0; i < checkArray.Length; i++)
            {
                checkArray[i] = array[i + 1];
            }
            */

            checkArray[0] = array[array.Length - array[0]];

            if (checkArray[0] == checkArray.Length - 1)
            {
                return true;
            }

            return PlayGame(checkArray);
        }
    }
}