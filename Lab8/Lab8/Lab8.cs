using System;
using System.Text;

namespace Lab8
{
    public static class Lab8
    {
        public static string PrettifyList(string s)
        {
            string checkNullOrWhiteSpace = s;
            checkNullOrWhiteSpace = checkNullOrWhiteSpace.Replace(" ", "");
            checkNullOrWhiteSpace = checkNullOrWhiteSpace.Replace("\n", "");
            checkNullOrWhiteSpace = checkNullOrWhiteSpace.Replace("\t", "");
            checkNullOrWhiteSpace = checkNullOrWhiteSpace.Replace("\r", "");
            checkNullOrWhiteSpace = checkNullOrWhiteSpace.Replace("\u2000", "");

            if (checkNullOrWhiteSpace.Length == 0 || checkNullOrWhiteSpace == null || checkNullOrWhiteSpace == string.Empty)
            {
                return null;
            }

            const int CAPACITY = 4096;
            string[] verticalSplit = s.Split('|');

            StringBuilder tempBuilder = new StringBuilder(CAPACITY);

            PrettifyListRecursive(verticalSplit, tempBuilder, 0);

            return tempBuilder.ToString();
        }

        public static string PrettifyListRecursive(string[] verticalSplit, StringBuilder tempBuilder, int index)
        {
            if (index == verticalSplit.Length)
            {
                return tempBuilder.ToString();
            }

            int asciiValue = 97;

            tempBuilder.AppendLine($"{index + 1}) {verticalSplit[index]}");

            int underIndex = tempBuilder.ToString().IndexOf('_');

            while (underIndex != -1)
            {
                tempBuilder.Replace("_", $"\n    {Convert.ToChar(asciiValue++)}) ", underIndex, 1);
                underIndex = tempBuilder.ToString().IndexOf('_');
            }

            tempBuilder.Replace("/", "\n        - ");

            PrettifyListRecursive(verticalSplit, tempBuilder, index + 1);

            return null;
        }
    }
}