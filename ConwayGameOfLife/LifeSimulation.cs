namespace ConwayGameOfLife
{
    public class LifeSimulation
    {
        private readonly IGridOperator _gridOperator;
        private readonly int _xLength;
        private readonly int _yLength;
        public int[,] CurrentState { get; private set; }

        public LifeSimulation(int[,] initialState, IGridOperator gridOperator)
        {
            _gridOperator = gridOperator;
            CurrentState = initialState;
            _xLength = CurrentState.GetLength(1);
            _yLength = CurrentState.GetLength(0);
        }

        public void NextGeneration()
        {
            int[,] nextGenerationState = new int[_yLength, _xLength];

            for (int y = 0; y < _yLength; y++)
            {
                for (int x = 0; x < _xLength; x++)
                {
                    int currentCellState = CurrentState[y, x];

                    var neighboursGrid = _gridOperator.GetNeighboursGrid(CurrentState, x, y);
                    int currentCellPositionX = x < 2 && x < _xLength - 2 ? x : 1;
                    int currentCellPositionY = y < 2 && y < _yLength - 2 ? y : 1;

                    int aliveNeighboursCount = _gridOperator.GetAliveNeighboursCount(neighboursGrid, currentCellPositionX, currentCellPositionY);
                    
                    nextGenerationState[y, x] = _gridOperator.IsAlive(currentCellState, aliveNeighboursCount); ;
                }
            }

            CurrentState = nextGenerationState;
        }
    }
}
