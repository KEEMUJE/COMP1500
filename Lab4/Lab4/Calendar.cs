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

            if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
            {
                bLeapYear = true;
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
            else
            {
                return GetDaysInMonth(year, month);
            }
        }
    }
}