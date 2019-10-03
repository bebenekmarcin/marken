using FluentAssertions;
using Xunit;

namespace ConwayGameOfLife.UnitTests
{
    public class GetNeighboursGridShould
    {
        private readonly GridOperator _gridOperator;

        public GetNeighboursGridShould()
        {
            _gridOperator = new GridOperator();
        }

        [Fact]
        public void GetNeighboursGridFromGridWithXDimension4AndYDimension3()
        {
            var grid = new[,]
            {
                {1, 1, 1, 0},
                {1, 1, 1, 0},
                {1, 1, 1, 0}
            };
            var expected = new[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };

            var neighboursGrid = _gridOperator.GetNeighboursGrid(grid, 1, 1);

            neighboursGrid.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetNeighboursGridFromGridWithXDimension4AndYDimension4()
        {
            var grid = new[,]
            {
                {1, 1, 1, 0},
                {1, 1, 1, 0},
                {1, 1, 1, 0},
                {0, 0, 0, 0}
            };
            var expected = new[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };

            var neighboursGrid = _gridOperator.GetNeighboursGrid(grid, 1, 1);

            neighboursGrid.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetNeighboursGridFromGridWithXDimension4AndYDimension4AndDifferentCellPosition()
        {
            var grid = new[,]
            {
                {1, 1, 1, 0},
                {1, 1, 1, 0},
                {1, 1, 1, 0},
                {0, 0, 0, 0}
            };
            var expected = new[,]
            {
                {1, 1, 0},
                {1, 1, 0},
                {0, 0, 0}
            };

            var neighboursGrid = _gridOperator.GetNeighboursGrid(grid, 2, 2);

            neighboursGrid.Should().BeEquivalentTo(expected);
        }
    }
}
