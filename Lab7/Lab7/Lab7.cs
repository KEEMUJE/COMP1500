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

            uint[] checkArray;

            if (array[0] == array[array.Length - 2])
            {
                checkArray = new uint[array.Length - 1];
            }
            else
            {
                checkArray = new uint[array.Length - array[0]];
            }

            checkArray[0] = array[array.Length - 1];

            if (checkArray[0] == checkArray.Length - 1)
            {
                return true;
            }

            return PlayGame(checkArray);
        }
    }
}