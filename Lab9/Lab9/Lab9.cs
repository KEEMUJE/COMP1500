using System;
using System.Collections.Generic;

namespace Lab9
{
    public static class Lab9
    {
        public static List<int> MergeLists(List<int> sortedList1, List<int> sortedList2)
        {
            List<int> mergeList = new List<int>();

            if (sortedList1 == null && sortedList2 == null)
            {
                return mergeList;
            }

            else if (sortedList1 == null)
            {
                return sortedList2;
            }

            else if (sortedList2 == null)
            {
                return sortedList1;
            }

            int firstListIndex = 0;
            int secondListIndex = 0;

            while (firstListIndex < sortedList1.Count || secondListIndex < sortedList2.Count)
            {
                if (firstListIndex > sortedList1.Count - 1)
                {
                    return PutRemainingList(ref mergeList, sortedList2, ref secondListIndex);
                }

                else if (secondListIndex > sortedList2.Count - 1)
                {
                    return PutRemainingList(ref mergeList, sortedList1, ref firstListIndex);
                }

                else if (sortedList1[firstListIndex] > sortedList2[secondListIndex])
                {
                    mergeList.Add(sortedList2[secondListIndex]);
                    ++secondListIndex;
                }

                else
                {
                    mergeList.Add(sortedList1[firstListIndex]);
                    ++firstListIndex;
                }
            }

            return mergeList;
        }

        public static List<int> PutRemainingList(ref List<int> mergeList, List<int> remainingList, ref int index)
        {
            for (int i = index; i < remainingList.Count; i++)
            {
                mergeList.Add(remainingList[i]);
                ++index;
            }

            return mergeList;
        }

        public static Dictionary<string, int> CombineListsToDictionary(List<string> keys, List<int> values)
        {
            Dictionary<string, int> combineDictionary = new Dictionary<string, int>();
            int index = 0;
            int limitLoop;

            if (keys.Count > values.Count)
            {
                limitLoop = values.Count;
            }
            else
            {
                limitLoop = keys.Count;
            }

            while (index < limitLoop)
            {
                combineDictionary.Add(keys[index], values[index]);
                ++index;

                if (index > keys.Count - 1)
                {
                    break;
                }

                index = keys.IndexOf(keys[index]) != keys.LastIndexOf(keys[index]) ? ++index : index;
            }

            return combineDictionary;
        }

        public static Dictionary<string, decimal> MergeDictionaries(Dictionary<string, int> numerators, Dictionary<string, int> denominators)
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();

            if (numerators.Count == 0 || denominators.Count == 0)
            {
                return result;
            }

            foreach (KeyValuePair<string, int> numeratorsKvp in numerators)
            {
                foreach (KeyValuePair<string, int> denominatorsKvp in denominators)
                {
                    if (numeratorsKvp.Key == denominatorsKvp.Key && denominatorsKvp.Value != 0)
                    {
                        result.Add(numeratorsKvp.Key, Math.Abs(numeratorsKvp.Value / (decimal)denominatorsKvp.Value));
                    }
                }
            }

            return result;
        }
    }
}