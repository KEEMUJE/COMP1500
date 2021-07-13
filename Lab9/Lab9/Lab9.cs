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
                return mergeList = sortedList2;
            }

            else if (sortedList2 == null)
            {
                return mergeList = sortedList1;
            }

            int firstListIndex = 0;
            int secondListIndex = 0;

            while (firstListIndex < sortedList1.Count || secondListIndex < sortedList2.Count)
            {
                if (firstListIndex > sortedList1.Count - 1)
                {
                    for (int i = secondListIndex; i < sortedList2.Count; i++)
                    {
                        mergeList.Add(sortedList2[i]);
                        ++secondListIndex;
                    }
                }

                else if (secondListIndex > sortedList2.Count - 1)
                {
                    for (int i = firstListIndex; i < sortedList1.Count; i++)
                    {
                        mergeList.Add(sortedList1[i]);
                        ++firstListIndex;
                    }
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

        public static Dictionary<string, int> CombineListsToDictionary(List<string> keys, List<int> values)
        {
            return null;
        }

        public static Dictionary<string, decimal> MergeDictionaries(Dictionary<string, int> numerators, Dictionary<string, int> denominators)
        {
            return null;
        }
    }
}