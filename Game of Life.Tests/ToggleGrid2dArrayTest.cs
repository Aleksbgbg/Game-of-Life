namespace Game.Tests
{
    using System;

    using Xunit;

    public class ToggleGrid2dArrayTest
    {
        [Fact]
        public void EmptyGrid_AllCellsFalse()
        {
            var grid = new ToggleGrid2dArray(new Size(2, 2));

            Assert.False(grid.IsCellSet(new Point(0, 0)));
            Assert.False(grid.IsCellSet(new Point(1, 0)));
            Assert.False(grid.IsCellSet(new Point(0, 1)));
            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void SetCell_IsSet()
        {
            var grid = new ToggleGrid2dArray(new Size(1, 1));

            grid.SetCell(new Point(0, 0));

            Assert.True(grid.IsCellSet(new Point(0, 0)));
        }

        [Fact]
        public void SetAndUnsetCell_IsNotSet()
        {
            var grid = new ToggleGrid2dArray(new Size(3, 3));

            grid.SetCell(new Point(2, 2));
            grid.UnsetCell(new Point(2, 2));

            Assert.False(grid.IsCellSet(new Point(2, 2)));
        }

        [Fact]
        public void GetCell_OutOfBounds_NegativeX_IsFalse()
        {
            var grid = new ToggleGrid2dArray(new Size(2, 2));

            Assert.False(grid.IsCellSet(new Point(-7, 1)));
        }

        [Fact]
        public void GetCell_OutOfBounds_PositiveX_IsFalse()
        {
            var grid = new ToggleGrid2dArray(new Size(2, 2));

            Assert.False(grid.IsCellSet(new Point(7, 1)));
        }

        [Fact]
        public void GetCell_OutOfBounds_NegativeY_IsFalse()
        {
            var grid = new ToggleGrid2dArray(new Size(2, 2));

            Assert.False(grid.IsCellSet(new Point(1, -7)));
        }

        [Fact]
        public void GetCell_OutOfBounds_PositiveY_IsFalse()
        {
            var grid = new ToggleGrid2dArray(new Size(2, 2));

            Assert.False(grid.IsCellSet(new Point(1, 7)));
        }

        [Fact]
        public void SetCell_OutOfBounds_Throws()
        {
            var grid = new ToggleGrid2dArray(new Size(0, 0));

            Assert.Throws<IndexOutOfRangeException>(() => grid.SetCell(new Point(10, 10)));
        }

        [Fact]
        public void UnsetCell_OutOfBounds_Throws()
        {
            var grid = new ToggleGrid2dArray(new Size(0, 0));

            Assert.Throws<IndexOutOfRangeException>(() => grid.SetCell(new Point(10, 10)));
        }
    }
}