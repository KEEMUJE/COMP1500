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
            List<String> prettifyList = ConvertPrettifyListRecursive(new List<string>(), new StringBuilder(CAPACITY), verticalSplit, 0);

            return string.Join("", prettifyList);
        }

        public static List<string> ConvertPrettifyListRecursive(List<string> outConsole, StringBuilder prettifyBuilder, string[] verticalSplit, int index)
        {
            if (index == verticalSplit.Length)
            {
                return outConsole;
            }

            int asciiValue = 97;
            int asciiLoop = 0;

            verticalSplit[index] = verticalSplit[index].Insert(0, $"{index + 1}) ");
            var underSplit = verticalSplit[index].Split('_');
            prettifyBuilder.AppendLine(underSplit[0].ToString());

            for (int i = 1; i < underSplit.Length; i++)
            {
                if (asciiValue > 122)
                {
                    asciiValue = 97;
                    asciiLoop += 1;
                }

                underSplit[i] = underSplit[i].Insert(0, $"    {Convert.ToChar(asciiValue++)}) ");

                for (int j = 0; j < asciiLoop; j++)
                {
                    underSplit[i] = underSplit[i].Insert(underSplit[i].IndexOf($"{Convert.ToChar(asciiValue - 1)}"), $"{Convert.ToChar(asciiValue - 1)}");
                }

                underSplit[i] = underSplit[i].Replace("/", "\n        - ");
                prettifyBuilder.AppendLine(underSplit[i].ToString());
            }

            outConsole.Add(prettifyBuilder.ToString());
            prettifyBuilder.Clear();

            ConvertPrettifyListRecursive(outConsole, prettifyBuilder, verticalSplit, index + 1);

            return outConsole;
        }
    }
}