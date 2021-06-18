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
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;

                case 2:
                    if (IsLeapYear(year))
                    {
                        return 29;
                    }

                    return 28;

                default:
                    break;
            }

            return -1;

            /* Solution 2
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
            else if (IsLeapYear(year))
            {
                return 29;
            }

            return 28;
            */
        }
    }
}