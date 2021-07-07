using System;
using System.Text;
using System.Collections.Generic;

namespace Lab8
{
    public static class Lab8
    {
        public static string PrettifyList(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s))
            {
                return null;
            }

            const int CAPACITY = 4096;
            string[] verticalSplit = s.Split('|');

            StringBuilder tempBuilder = new StringBuilder(CAPACITY);

            List<String> convert = PrettifyListRecursive(new List<string>(), tempBuilder, verticalSplit, 0);

            return string.Join("", convert);
        }

        public static List<string> PrettifyListRecursive(List<string> outConsole, StringBuilder tempBuilder, string[] verticalSplit, int index)
        {
            if (index == verticalSplit.Length)
            {
                return outConsole;
            }

            int asciiValue = 97;

            tempBuilder.AppendLine($"{index + 1}) {verticalSplit[index]}");

            int underIndex = tempBuilder.ToString().IndexOf('_');

            while (underIndex != -1)
            {
                tempBuilder.Replace("_", $"\n    {Convert.ToChar(asciiValue++)}) ", underIndex, 1);
                tempBuilder.Replace("/", "\n        - ");
                underIndex = tempBuilder.ToString().IndexOf('_');
            }

            outConsole.Add(tempBuilder.ToString());
            tempBuilder.Clear();

            PrettifyListRecursive(outConsole, tempBuilder, verticalSplit, index + 1);

            return outConsole;
        }
    }
}