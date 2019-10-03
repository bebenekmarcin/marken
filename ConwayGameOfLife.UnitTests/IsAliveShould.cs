using FluentAssertions;
using Xunit;

namespace ConwayGameOfLife.UnitTests
{
    public class IsAliveShould
    {
        private readonly GridOperator _gridOperator;

        public IsAliveShould()
        {
            _gridOperator = new GridOperator();
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Die_WhenCellIsAliveAndHasLessThan2AliveNeighbours(int numberOfLiveNeighbors)
        {
            _gridOperator.IsAlive(1, numberOfLiveNeighbors).Should().Be(0);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Live_WhenCellIsAliveAndHasLess2or3AliveNeighbours(int numberOfLiveNeighbors)
        {
            _gridOperator.IsAlive(1, numberOfLiveNeighbors).Should().Be(1);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Die_WhenCellIsAliveAndHasMoreThan3AliveNeighbours(int numberOfLiveNeighbors)
        {
            _gridOperator.IsAlive(1, numberOfLiveNeighbors).Should().Be(0);
        }

        [Theory]
        [InlineData(3)]
        public void Live_WhenCellIsDeadAndHas3AliveNeighbours(int numberOfLiveNeighbors)
        {
            _gridOperator.IsAlive(0, numberOfLiveNeighbors).Should().Be(1);
        }
    }
}
