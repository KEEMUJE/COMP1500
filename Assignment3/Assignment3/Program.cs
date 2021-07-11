using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = TowerOfHanoi.GetNumberOfSteps(-2);
            Debug.Assert(steps == -1);

            steps = TowerOfHanoi.GetNumberOfSteps(0);
            Debug.Assert(steps == 0);

            steps = TowerOfHanoi.GetNumberOfSteps(3);
            Debug.Assert(steps == 7);

            var snapshots = TowerOfHanoi.SolveTowerOfHanoi(-1);
            Console.Write($"NegativeNvalue");
            Debug.Assert(snapshots.Count == 0);
            Console.WriteLine(" - Success\n");

            snapshots = TowerOfHanoi.SolveTowerOfHanoi(0);
            Console.Write($"ZeroDisks");
            Debug.Assert(snapshots.Count == 0);
            Console.WriteLine(" - Success\n");
            Console.WriteLine("------------------------------------------------");

            snapshots = TowerOfHanoi.SolveTowerOfHanoi(1);
            Console.WriteLine($"OneDisk\n");
            Debug.Assert(isEqual(snapshots[0][0], new List<int> { 1 }));
            Debug.Assert(snapshots[0][1].Count == 0);
            Debug.Assert(snapshots[0][2].Count == 0);

            Debug.Assert(snapshots[1][0].Count == 0);
            Debug.Assert(snapshots[1][1].Count == 0);
            Debug.Assert(isEqual(snapshots[1][2], new List<int> { 1 }));

            printSnapshots(snapshots);
            Console.WriteLine("------------------------------------------------");

            snapshots = TowerOfHanoi.SolveTowerOfHanoi(3);
            Console.WriteLine($"numDiscs : 3\n");
            Debug.Assert(isEqual(snapshots[0][0], new List<int> { 3, 2, 1 }));
            Debug.Assert(snapshots[0][1].Count == 0);
            Debug.Assert(snapshots[0][2].Count == 0);

            Debug.Assert(isEqual(snapshots[1][0], new List<int> { 3, 2 }));
            Debug.Assert(snapshots[1][1].Count == 0);
            Debug.Assert(isEqual(snapshots[1][2], new List<int> { 1 }));

            Debug.Assert(isEqual(snapshots[2][0], new List<int> { 3 }));
            Debug.Assert(isEqual(snapshots[2][1], new List<int> { 2 }));
            Debug.Assert(isEqual(snapshots[2][2], new List<int> { 1 }));

            Debug.Assert(isEqual(snapshots[3][0], new List<int> { 3 }));
            Debug.Assert(isEqual(snapshots[3][1], new List<int> { 2, 1 }));
            Debug.Assert(snapshots[3][2].Count == 0);

            Debug.Assert(snapshots[4][0].Count == 0);
            Debug.Assert(isEqual(snapshots[4][1], new List<int> { 2, 1 }));
            Debug.Assert(isEqual(snapshots[4][2], new List<int> { 3 }));

            Debug.Assert(isEqual(snapshots[5][0], new List<int> { 1 }));
            Debug.Assert(isEqual(snapshots[5][1], new List<int> { 2 }));
            Debug.Assert(isEqual(snapshots[5][2], new List<int> { 3 }));

            Debug.Assert(isEqual(snapshots[6][0], new List<int> { 1 }));
            Debug.Assert(snapshots[6][1].Count == 0);
            Debug.Assert(isEqual(snapshots[6][2], new List<int> { 3, 2 }));

            Debug.Assert(snapshots[7][0].Count == 0);
            Debug.Assert(snapshots[7][1].Count == 0);
            Debug.Assert(isEqual(snapshots[7][2], new List<int> { 3, 2, 1 }));

            printSnapshots(snapshots);
        }

        private static void printSnapshots(List<List<int>[]> snapshots)
        {

            Console.WriteLine($"└ [");
            Console.WriteLine();
            for (int i = 0; i < snapshots.Count; i++)
            {
                Console.Write($"\0\0\0【\0");
                Console.Write($"└ [ {string.Join(", ", snapshots[i][0]),7} ]");
                Console.Write($"└ [ {string.Join(", ", snapshots[i][1]),7} ]");
                Console.Write($"└ [ {string.Join(", ", snapshots[i][2]),7} ]");

                if (i == snapshots.Count)
                {
                    Console.WriteLine($"\0\0】");
                }

                else
                {
                    Console.WriteLine($"\0\0】");
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"  ]");
            Console.WriteLine();
        }

        private static bool isEqual(List<int> actual, List<int> expected)
        {
            if (actual.Count != expected.Count)
            {
                return false;
            }

            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
