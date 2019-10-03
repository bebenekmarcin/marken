namespace ConwayGameOfLife
{
    public class GridOperator : IGridOperator
    {
        public int GetAliveNeighboursCount(int[,] neighbours, int currentCellPositionX, int currentCellPositionY)
        {
            int aliveNeighboursCount = 0;
            int xLength = neighbours.GetLength(1);
            int yLength = neighbours.GetLength(0);
            int startY = currentCellPositionY > 1 ? currentCellPositionY - 1 : 0;
            int startX = currentCellPositionX > 1 ? currentCellPositionX - 1 : 0;

            for (int y = startY; y < yLength; y++)
            {
                for (int x = startX; x < xLength; x++)
                {
                    if (x != currentCellPositionX || y != currentCellPositionY)
                    {
                        aliveNeighboursCount += neighbours[y, x];
                    }
                }
            }

            return aliveNeighboursCount;
        }

        public int IsAlive(int isAliveNow, int numberOfAliveNeighbors)
        {
            if (isAliveNow == 1 && numberOfAliveNeighbors < 2)
                return 0;

            if (isAliveNow == 1 && (numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3))
                return 1;

            if (isAliveNow == 1 && numberOfAliveNeighbors > 3)
                return 0;

            if (isAliveNow == 0 && numberOfAliveNeighbors == 3)
                return 1;

            return isAliveNow;
        }
        
        public int[,] GetNeighboursGrid(int[,] grid, int currentCellPositionX, int currentCellPositionY)
        {
            int yLength = grid.GetLength(0);
            int startY = currentCellPositionY > 1 ? currentCellPositionY - 1 : 0;
            int endY = currentCellPositionY + 2 < yLength ? currentCellPositionY + 2 : yLength;

            int xLength = grid.GetLength(1);
            int startX = currentCellPositionX > 1 ? currentCellPositionX - 1 : 0;
            int endX = currentCellPositionX + 2 < xLength ? currentCellPositionX + 2 : xLength;

            var neighboursGrid = new int[endY - startY, endX - startX];

            int j = 0;
            int i = 0;
            for (int y = startY; y < endY; y++, j++)
            {
                for (int x = startX; x < endX; x++, i++)
                {
                    neighboursGrid[j, i] = grid[y, x];
                }

                i = 0;
            }

            return neighboursGrid;
        }
    }
}
