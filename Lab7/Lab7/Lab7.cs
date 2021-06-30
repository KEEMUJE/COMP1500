namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            // array = new uint[9] { 4, 3, 4, 4, 1, 5, 7, 1, 0 };
            // bPass = Lab7.PlayGame(array); // true
            // array = new uint[10] { 6, 1, 5, 2, 4, 8, 2, 1, 4, 0 };
            // bPass = Lab7.PlayGame(array); // false

            if (array.Length <= 1 || array[0] > array.Length - 1 || array[0] == 0)
            {
                return false;
            }

            if (array[0] == array.Length - 1)
            {
                return true;
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

            checkArray[0] = array[array.Length - 2];

            if (checkArray[0] == checkArray.Length - 1)
            {
                return true;
            }

            return PlayGame(checkArray);
        }
    }
}