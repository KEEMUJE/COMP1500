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
            uint checker = 0;

            return GameVerification(array, checker, myPosition);
        }

        public static bool GameVerification(uint[] array, uint checker, uint myPosition)
        {
            if (myPosition > array.Length - 1 || myPosition < 1)
            {
                return false;
            }

            if (array[myPosition] == 0)
            {
                return true;
            }

            if (checker > 10)
            {
                return false;
            }

            return GameVerification(array, checker += 1, myPosition + array[myPosition]) ||
                   GameVerification(array, checker += 1, myPosition - array[myPosition]);
        }
    }
}