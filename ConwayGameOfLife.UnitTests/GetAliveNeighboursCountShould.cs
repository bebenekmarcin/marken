using FluentAssertions;
using Xunit;

namespace ConwayGameOfLife.UnitTests
{
    public class GetAliveNeighboursCountShould
    {
        private readonly GridOperator _gridOperator;

        public GetAliveNeighboursCountShould()
        {
            _gridOperator = new GridOperator();
        }

        [Fact]
        public void Return0_WhenHas0AliveNeighbour()
        {
            var neighbours = new[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, 1, 1);

            number.Should().Be(0);
        }


        [Fact]
        public void Return1_WhenIsDeadAndHas3AliveNeighbours()
        {
            var neighbours = new[,]
            {
                {0, 0, 1},
                {0, 0, 1},
                {0, 0, 1}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, 1, 1);

            number.Should().Be(3);
        }

        [Fact]
        public void Return1_WhenHas1AliveNeighbour()
        {
            var neighbours = new[,]
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, 1, 1);

            number.Should().Be(1);
        }

        [Fact]
        public void Return2_WhenHas2AliveNeighbours()
        {
            var neighbours = new[,]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, 1, 1);

            number.Should().Be(2);
        }

        [Fact]
        public void Return8_WhenHas8AliveNeighbours()
        {
            var neighbours = new[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, 1, 1);

            number.Should().Be(8);
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(0, 0, 2)]
        [InlineData(2, 1, 1)]
        [InlineData(0, 2, 1)]
        public void ReturnExpectedCount_WhenYDimensionIs2(int currentCellPositionX, int currentCellPositionY, int expectedCount)
        {
            var neighbours = new[,]
            {
                {0, 1, 0},
                {1, 0, 0}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, currentCellPositionX, currentCellPositionY);

            number.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 1, 1)]
        public void ReturnExpectedCount_WhenXDimensionIs2YDimensionIs2(int currentCellPositionX, int currentCellPositionY, int expectedCount)
        {
            var neighbours = new[,]
            {
                {1, 0},
                {0, 0}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, currentCellPositionX, currentCellPositionY);

            number.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 1)]
        public void ReturnExpectedCount_WhenXDimensionIs2YDimensionIs2ForDifferentInitialState(int currentCellPositionX, int currentCellPositionY, int expectedCount)
        {
            var neighbours = new[,]
            {
                {0, 0},
                {1, 0}
            };

            int number = _gridOperator.GetAliveNeighboursCount(neighbours, currentCellPositionX, currentCellPositionY);

            number.Should().Be(expectedCount);
        }
    }
}
