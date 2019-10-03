using System;
using System.Threading;

namespace ConwayGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 45;
            int[,] initialState = GetCrossInitialState(length);

            LifeSimulation lifeSimulation = new LifeSimulation(initialState, new GridOperator());
            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                Console.WriteLine($"Generation number: {i}\n");

                for (int y = 0; y < length; y++)
                {
                    for (int x = 0; x < length; x++)
                    {
                        Console.Write(lifeSimulation.CurrentState[y, x] == 1 ? "X" : " ");
                    }
                    Console.WriteLine();
                }
                lifeSimulation.NextGeneration();
                Thread.Sleep(50);
            }
        }

        private static int[,] GetCrossInitialState(int length)
        {
            int[,] grid = new int[length, length];
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    if (x == y || x == length - y - 1)
                    {
                        grid[y, x] = 1;
                    }
                }
            }

            return grid;
        }
    }
}
