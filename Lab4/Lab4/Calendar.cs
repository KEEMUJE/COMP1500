namespace Lab4
{
    public static class Calendar
    {
        public static bool IsLeapYear(uint year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        public static int GetDaysInMonth(uint year, uint month)
        {
            // Solution 1
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
            else if (month == 2 && (year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return 29;
            }
            else
            {
                return 28;
            }

            /*
            // Solution 2
            if (year > 9999 || month < 1 || month > 12)
            {
                return -1;
            }
            else if (month == 2)
            {
                return IsLeapYear(year) ? 29 : 28;
            }
            else if (month <= 7)
            {
                return month % 2 == 0 ? 30 : 31;
            }
            else
            {
                return month % 2 == 0 ? 31 : 30;
            }
            */
        }
    }
}