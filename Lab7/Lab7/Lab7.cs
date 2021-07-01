namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            if (array.Length <= 1)
            {
                return false;
            }

            uint myPosition = array[0];
            uint[] checkArray = new uint[array.Length];

            return GameVerification(array, checkArray, myPosition);
        }

        public static bool GameVerification(uint[] array, uint[] checkArray, uint myPosition)
        {
            if (myPosition > array.Length - 1 || myPosition < 1)
            {
                return false;
            }

            if (array[myPosition] == 0)
            {
                return true;
            }



            return GameVerification(array, checkArray, myPosition + array[myPosition]) ||
                   GameVerification(array, checkArray, myPosition - array[myPosition]);
        }
    }
}