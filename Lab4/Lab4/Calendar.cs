namespace Lab4
{
    public static class Calendar
    {
        public static bool IsLeapYear(uint year)
        {
            bool bLeapYear;

            if (year % 400 == 0)
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
            else if (month < 0 || month > 12)
            {
                return -1;
            }

            return -1;
        }
    }
}