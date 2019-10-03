using System;
using System.Threading;

namespace ConwayGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] initialState = new[,]
            //{
            //    {1, 0, 1, 1, 1},
            //    {0, 1, 1, 0, 0},
            //    {0, 0, 0, 0, 1},
            //    {1, 1, 1, 0, 0},
            //    {0, 0, 0, 1, 1}
            //};

            //int[,] initialState = new[,]
            //{
            //    {1, 0, 0, 0, 1},
            //    {0, 1, 0, 1, 0},
            //    {0, 0, 1, 0, 1},
            //    {0, 1, 0, 1, 0},
            //    {1, 0, 0, 0, 1}
            //};

            //int[,] initialState = new[,]
            //{
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            //};

            int[,] initialState = GetCrossInitialState(45);


            int xLength = initialState.GetLength(1);
            int yLength = initialState.GetLength(0);

            LifeSimulation lifeSimulation = new LifeSimulation(initialState, new GridOperator());
            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                for (int y = 0; y < yLength; y++)
                {
                    for (int x = 0; x < xLength; x++)
                    {
                        Console.Write(lifeSimulation.CurrentState[y, x] == 1 ? "X" : " ");
                    }
                    Console.WriteLine();
                }
                lifeSimulation.NextGeneration();
                Thread.Sleep(100);
            }


            Console.WriteLine("Hello World!");
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
