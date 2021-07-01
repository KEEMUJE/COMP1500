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

            /* 인덱스  0  1  2  3  4  5  6  7  8
            배열값  4  3  4  4  1  5  7  1  0
            위에거 예를 들어보자면 위에는 인덱스를 가리키고 밑에는 배열값이에요
            시작점은 인덱스0이 결정해줘요 값이 4네요? 그럼 인덱스4인곳에서 ‘시작’ 합니다
            인덱스 4의 값이 1이네요 그럼 좌로 1 이동하거나 우로 1 ‘이동할 수’ 있습니다
            할 수 있다는 의미는 가능하면 간다는거에요
            예를 들면 인덱스 6에 도착했다고 해봅시다 값을 보면 7이죠?
            그럼 6에서 좌로 7만큼 가면  -1이네요 여긴 갈 수 없죠
            우로 가볼까요 ? 13이네요 여기도 갈 수 없네요 */
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