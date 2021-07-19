using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class TowerOfHanoi
    {
        const byte NUMBER_OF_STICKS = 3;

        public static int GetNumberOfSteps(int numDiscs)
        {
            if (numDiscs < 0)
            {
                return -1;
            }

            return (int)Math.Pow(2, numDiscs) - 1;
        }

        public static List<List<int>[]> SolveTowerOfHanoi(int numDiscs)
        {
            if (numDiscs < 1)
            {
                return new List<List<int>[]>();
            }

            int index = 0;
            int loopLimit = (int)Math.Pow(2, numDiscs) - 1;
            List<List<int>[]> snapshots = new List<List<int>[]>();
            snapshots.Add(new List<int>[NUMBER_OF_STICKS]);
            snapshots[index][0] = new List<int>();
            snapshots[index][1] = new List<int>();
            snapshots[index][2] = new List<int>();

            for (int i = 0; i < numDiscs; i++)
            {
                snapshots[index][index].Add(numDiscs - i);
            }

            if (numDiscs == 1)
            {
                snapshots.Add(new List<int>[NUMBER_OF_STICKS]);
                snapshots[++index][0] = new List<int>();
                snapshots[index][1] = new List<int>();
                snapshots[index][2] = new List<int>();
                snapshots[index][2].Add(numDiscs);
                return snapshots;
            }

            return SolveRecursive(numDiscs, index, loopLimit, snapshots, new List<int>(), new List<int>(), new List<int>());
        }

        public static List<List<int>[]> SolveRecursive(int numDiscs, int index, int loopLimit, List<List<int>[]> snapshots, List<int> pole1, List<int> pole3, List<int> pole2)
        {
            pole1 = snapshots[index][0];
            pole3 = snapshots[index][1];
            pole2 = snapshots[index][2];
            snapshots.Add(snapshots[index]);

            return snapshots;
        }
    }
}

/*
using System.Collections.Generic;
​
namespace Assignment3
{
    public static class TowerOfHanoi
    {
        public static int GetNumberOfSteps(int numDiscs)
        {
            if (numDiscs == 0)
            {
                return 0;
            }
​
            return numDiscs < 0 ? -1 : 2 * GetNumberOfSteps(numDiscs - 1) + 1;
        }
​
        public static List<List<int>[]> SolveTowerOfHanoi(int numDiscs)
        {
            List<List<int>[]> result = new List<List<int>[]>();
​
            if (numDiscs < 1)
            {
                return result;
            }
​
            List<int>[] startBar = new List<int>[3];
            List<int>[] endBar = new List<int>[3];
​
            startBar[0] = new List<int> { numDiscs };
            startBar[1] = new List<int>();
            startBar[2] = new List<int>();
​
            endBar[0] = new List<int>();
            endBar[1] = new List<int>();
            endBar[2] = new List<int> { numDiscs };
​
            if (numDiscs == 1)
            {
                result.Add(startBar);
                result.Add(endBar);
                return result;
            }
​
            var assumption1 = SolveTowerOfHanoi(numDiscs - 1);
            var assumption2 = SolveTowerOfHanoi(numDiscs - 1);
​
            foreach (var index in assumption1)
            {
                index[0].Insert(0, numDiscs);
                var tempindex = index[1];
                index[1] = index[2];
                index[2] = tempindex;
                result.Add(index);
            }
​
            foreach (var index in assumption2)
            {
                index[2].Insert(0, numDiscs);
                var tempindex = index[1];
                index[1] = index[0];
                index[0] = tempindex;
                result.Add(index);
            }
​
            return result;
        }
    }
}
*/