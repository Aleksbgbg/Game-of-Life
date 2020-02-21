namespace Game.Tests.Integration
{
    using Xunit;

    public class SpaceshipTest
    {
        [Fact]
        public void GliderSpaceship_MovesOneHundredSpacesDiagonally_AfterFourHundredEvolutions()
        {
            Size gridSize = new Size(103, 103);
            var grid = new ToggleGrid2dArray(gridSize);
            grid.SetCell(new Point(0, 1));
            grid.SetCell(new Point(1, 2));
            grid.SetCell(new Point(2, 0));
            grid.SetCell(new Point(2, 1));
            grid.SetCell(new Point(2, 2));
            Game game = new Game(grid, new ToggleGrid2dArray(gridSize));

            for (int evolution = 0; evolution < 400; ++evolution)
            {
                game.Evolve();
            }

            Assert.True(grid.IsCellSet(new Point(100, 101)));
            Assert.True(grid.IsCellSet(new Point(101, 102)));
            Assert.True(grid.IsCellSet(new Point(102, 100)));
            Assert.True(grid.IsCellSet(new Point(102, 101)));
            Assert.True(grid.IsCellSet(new Point(102, 102)));
        }
    }
}