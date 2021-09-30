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

            if (checker > 50) // checker라는 변수를 사용한 겻보다, boolean 배열을 선언하여 방문 여부 체크가 더 나은 방법
            {
                return false;
            }
            
            return GameVerification(array, checker += 1, myPosition + array[myPosition]) ||
                   GameVerification(array, checker += 1, myPosition - array[myPosition]);
        }
    }
}
