namespace ConwayGameOfLife
{
    public interface IGridOperator
    {
        int[,] GetNeighboursGrid(int[,] grid, int currentCellPositionX, int currentCellPositionY);
        int GetAliveNeighboursCount(int[,] neighbours, int currentCellPositionX, int currentCellPositionY);
        int IsAlive(int isAliveNow, int numberOfAliveNeighbors);
    }
}