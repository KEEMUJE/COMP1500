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
                return null;
            }

            int index = 0;

            List<List<int>[]> snapshots = new List<List<int>[]>();
            snapshots.Add(new List<int>[NUMBER_OF_STICKS]);

            for (int i = 0; i < NUMBER_OF_STICKS; i++)
            {
                snapshots[index][i] = new List<int>();
            }

            var from = snapshots[index][0];
            var aux = snapshots[index][1];
            var to = snapshots[index][2];

            for (int i = 0; i < numDiscs; i++)
            {
                from.Add(numDiscs - i);
            }

            return SolveTowerOfHanoiRecursive(numDiscs, ++index, snapshots, from, aux, to);
        }

        public static List<List<int>[]> SolveTowerOfHanoiRecursive(int numDiscs, int index, List<List<int>[]> snapshots, List<int> from, List<int> aux, List<int> to)
        {
            if (numDiscs <= 1)
            {
                to.Add(from[from.Count - 1]);
                from.Remove(to[to.Count - 1]);
                return snapshots;
            }

            snapshots.Add(new List<int>[NUMBER_OF_STICKS]);

            for (int i = 0; i < NUMBER_OF_STICKS; i++)
            {
                snapshots[index][i] = new List<int>();
            }

            return snapshots;
        }
    }
}