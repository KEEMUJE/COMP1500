namespace Lab4
{
    public static class Calendar
    {
        public static bool IsLeapYear(uint year)
        {
            bool bLeapYear;

            if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
            {
                bLeapYear = true;
            }
            else if (year % 400 == 0)
            {
                bLeapYear = false;
            }
            else if (year % 100 == 0)
            {
                bLeapYear = false;
            }
            else if (year % 4 == 0)
            {
                bLeapYear = true;
            }
            else
            {
                bLeapYear = false;
            }
            return bLeapYear;
        }

        public static int GetDaysInMonth(uint year, uint month)
        {
            if (year > 9999)
            {
                return -1;
            }
            else if (month < 1 || month > 12)
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
            // year, month의 값을 논리곱 연산을 통해 윤년의 2월인지 아닌지를 판단
            else if (year % 400 == 0 && year % 100 == 0 && year % 4 == 0 && month == 2)
            {
                return 29;
            }
            else if (year % 400 == 0 && month == 2)
            {
                return 28;
            }
            else if (year % 100 == 0 && month == 2)
            {
                return 28;
            }
            else if (year % 4 == 0 && month == 2)
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
    }
}