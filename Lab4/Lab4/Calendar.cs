namespace Lab4
{
    public static class Calendar
    {
        public static bool IsLeapYear(uint year)
        {
            return (year % 4 == 0 && year % 100 == 0 && year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }

        public static int GetDaysInMonth(uint year, uint month)
        {
            if (year > 9999 || month < 1 || month > 12)
            {
                return -1;
            }
            else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            else if ((month == 2 && year % 4 == 0 && year % 100 == 0 && year % 400 == 0) || (month == 2 && year % 4 == 0 && year % 100 != 0))
            {
                return 29;
            }
            else // 위 모든 불리언 표현식이 거짓이라면 윤년이 아니다.
            {
                return 28;
            }
        }
    }
}