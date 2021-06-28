namespace Lab7
{
    public static class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            if (array.Length <= 1 || array[0] > array.Length - 1)
            {
                return false;
            }

            return false;
        }

        public static bool GameVerification(uint[] array)
        {
            // 종료 조건 = array[array.Length - 1]에 도착할 때 || 도착하지 못한다고 판별 됐을 때.
            // array = new uint[9] { 4, 3, 4, 4, 1, 5, 7, 1, 0 };

            return true;
        }
    }
}