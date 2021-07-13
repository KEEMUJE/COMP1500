using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1;
            List<int> list2;

            List<int> combinedList;
            List<int> expectedList;

            list1 = new List<int> { 1, 1, 4, 7, 8, 11, 20 };
            list2 = new List<int> { 2, 3, 4, 5, 10, 15, 16, 21, 22 };


            combinedList = Lab9.MergeLists(list1, list2);
            expectedList = new List<int> { 1, 1, 2, 3, 4, 4, 5, 7, 8, 10, 11, 15, 16, 20, 21, 22 };

            Console.WriteLine($"[ {string.Join(", ", combinedList)} ]");

            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == combinedList[i]);
            }

            list1 = new List<int> { 1, 1, 4 };
            list2 = new List<int> { 2, 3, 3 };

            combinedList = Lab9.MergeLists(list1, list2);
            expectedList = new List<int> { 1, 1, 2, 3, 3, 4 };

            Console.WriteLine($"[ {string.Join(", ", combinedList)} ]");
            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == combinedList[i]);
            }

            list1 = new List<int> { 1, 1, 4 };
            list2 = null;

            combinedList = Lab9.MergeLists(list1, list2);
            expectedList = new List<int> { 1, 1, 4 };

            Console.WriteLine($"[ {string.Join(", ", combinedList)} ]");
            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == combinedList[i]);
            }

            list1 = null;
            list2 = new List<int> { 2, 3, 3 };

            combinedList = Lab9.MergeLists(list1, list2);
            expectedList = new List<int> { 2, 3, 3 };

            Console.WriteLine($"[ {string.Join(", ", combinedList)} ]");
            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == combinedList[i]);
            }

            list1 = new List<int> { };
            list2 = new List<int> { };
            combinedList = Lab9.MergeLists(list1, list2);
            Debug.Assert(combinedList.Count == 0);

            list1 = null;
            list2 = null;
            combinedList = Lab9.MergeLists(list1, list2);
            Debug.Assert(combinedList.Count == 0);

            List<string> keys = new List<string> { "hello", "world", "comp1500", "intro", "to", "c#" };
            List<int> values = new List<int> { 2, 5, 10, 40, -11, -50 };

            Dictionary<string, int> dict = Lab9.CombineListsToDictionary(keys, values);
            Dictionary<string, int> expectedDict = new Dictionary<string, int>
            {
                { "hello", 2 },
                { "world", 5 },
                { "comp1500", 10 },
                { "intro", 40 },
                { "to", -11 },
                { "c#", -50 }
            };

            printDictionary(dict);

            Debug.Assert(dict.Count == expectedDict.Count);

            foreach (var keyvaluePair in expectedDict)
            {
                Debug.Assert(keyvaluePair.Value == dict[keyvaluePair.Key]);
            }

            List<string> keys2 = new List<string> { "a", "a", "b", "c", "a", "d" };
            List<int> values2 = new List<int> { 1, 2, 3, 4, 5, 6 };
            Dictionary<string, int> dict2 = Lab9.CombineListsToDictionary(keys2, values2);
            Dictionary<string, int> expectedDict2 = new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 3 },
                { "c", 4 },
                { "d", 6 }
            };
            Debug.Assert(dict2.Count == expectedDict2.Count);
            foreach (var keyvaluePair in expectedDict2)
            {
                Debug.Assert(keyvaluePair.Value == dict2[keyvaluePair.Key]);
            }

            Dictionary<string, int> numerators = new Dictionary<string, int>
            {
                { "a", 53 },
                { "b", -14 },
                { "c", 5 },
                { "d", 235 },
                { "g", 1 },
            };
            Dictionary<string, int> denominators = new Dictionary<string, int>
            {
                { "a", 77 },
                { "b", 235 },
                { "c", -3 },
                { "d", 121 },
                { "e", 8 },
                { "f", -621 },
            };

            Dictionary<string, decimal> result = Lab9.MergeDictionaries(numerators, denominators);
            Dictionary<string, decimal> expectedResult = new Dictionary<string, decimal>
            {
                { "a", 0.6883116883116883116883116883m },
                { "b", 0.0595744680851063829787234043m },
                { "c", 1.6666666666666666666666666667m },
                { "d", 1.9421487603305785123966942149m }
            };

            printDictionary(result);

            Debug.Assert(expectedResult.Count == result.Count);

            foreach (var keyvaluePair in expectedResult)
            {
                Debug.Assert(keyvaluePair.Value == result[keyvaluePair.Key]);
            }
        }

        private static void printDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");

            foreach (var keyvaluepair in dict)
            {
                sb.Append($"{{ {keyvaluepair.Key}, {keyvaluepair.Value} }}, ");
            }

            string s = sb.ToString().Trim().Trim(',');
            Console.WriteLine($"{s} ]");
        }
    }
}