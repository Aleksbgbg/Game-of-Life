namespace Game.Tests
{
    using Xunit;

    public class GameTest
    {
        [Fact]
        public void AliveCell_ZeroNeighbours_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 0;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_OneNeighbour_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 1;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_TwoNeighbours_Survives()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 2;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.True(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_ThreeNeighbours_Survives()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 3;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.True(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_FourNeighbours_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 4;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_FiveNeighbours_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 5;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_SixNeighbours_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 6;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_SevenNeighbours_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 7;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void AliveCell_EightNeighbours_Dies()
        {
            const bool middleCellAlive = true;
            const int aliveNeighbours = 8;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.False(grid.IsCellSet(new Point(1, 1)));
        }

        [Fact]
        public void DeadCell_ThreeNeighbours_BecomesAlive()
        {
            const bool middleCellAlive = false;
            const int aliveNeighbours = 3;
            var grid = Setup3x3Grid(middleCellAlive, aliveNeighbours);
            Game game = SetupGame(grid);

            game.Evolve();

            Assert.True(grid.IsCellSet(new Point(1, 1)));
        }

        private static IToggleGrid Setup3x3Grid(bool middleCellIsAlive, int aliveCellsSurroundingMiddle)
        {
            var grid = new ToggleGrid2dArray(new Size(3, 3));

            if (middleCellIsAlive)
            {
                grid.SetCell(new Point(1, 1));
            }

            Point[] points =
            {
                new Point(0, 0),
                new Point(1, 0),
                new Point(2, 0),
                new Point(0, 1),
                new Point(2, 1),
                new Point(0, 2),
                new Point(1, 2),
                new Point(2, 2),
            };

            int index = -1;

            for (int i = 0; i < aliveCellsSurroundingMiddle; ++i)
            {
                grid.SetCell(points[++index]);
            }

            return grid;
        }

        private static Game SetupGame(IToggleGrid grid)
        {
            return new Game(grid, new ToggleGrid2dArray(grid.Size));
        }
    }
}