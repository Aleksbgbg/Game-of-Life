namespace Game
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Game
    {
        private readonly IToggleGrid _readGrid;

        private readonly IToggleGrid _writeGrid;

        private readonly Size _gridSize;

        private Point _currentPoint;

        public Game(IToggleGrid dataGrid, IToggleGrid sandboxGrid)
        {
            Debug.Assert(dataGrid.Size.Equals(sandboxGrid.Size));

            _readGrid = dataGrid;
            _writeGrid = sandboxGrid;
            _gridSize = _readGrid.Size;
        }

        public void Evolve()
        {
            for (int x = 0; x < _gridSize.Width; ++x)
            {
                for (int y = 0; y < _gridSize.Height; ++y)
                {
                    _currentPoint = new Point(x, y);
                    EvolveCurrentCell();
                }
            }

            CopyWriteGridToReadGrid();
        }

        private void EvolveCurrentCell()
        {
            int aliveNeighbours = CountAliveNeighboursAroundCurrentCell();

            if (CurrentCellIsAlive())
            {
                if (aliveNeighbours == 2 || aliveNeighbours == 3)
                {
                    SetCurrentCellAlive();
                }
                else
                {
                    SetCurrentCellDead();
                }
            }
            else
            {
                if (aliveNeighbours == 3)
                {
                    SetCurrentCellAlive();
                }
            }
        }

        private bool CurrentCellIsAlive()
        {
            return CellIsAlive(_currentPoint);
        }

        private void SetCurrentCellAlive()
        {
            _writeGrid.SetCell(_currentPoint);
        }

        private void SetCurrentCellDead()
        {
            _writeGrid.UnsetCell(_currentPoint);
        }

        private int CountAliveNeighboursAroundCurrentCell()
        {
            return PointsAround(_currentPoint).Count(CellIsAlive);
        }

        private bool CellIsAlive(Point point)
        {
            return _readGrid.IsCellSet(point);
        }

        private static IEnumerable<Point> PointsAround(Point point)
        {
            int x = point.X;
            int y = point.Y;

            yield return new Point(x - 1, y - 1);
            yield return new Point(x, y - 1);
            yield return new Point(x + 1, y - 1);
            yield return new Point(x - 1, y);
            yield return new Point(x + 1, y);
            yield return new Point(x - 1, y + 1);
            yield return new Point(x, y + 1);
            yield return new Point(x + 1, y + 1);
        }

        private void CopyWriteGridToReadGrid()
        {
            for (int x = 0; x < _gridSize.Width; ++x)
            {
                for (int y = 0; y < _gridSize.Height; ++y)
                {
                    Point point = new Point(x, y);

                    if (_writeGrid.IsCellSet(point))
                    {
                        _readGrid.SetCell(point);
                    }
                    else
                    {
                        _readGrid.UnsetCell(point);
                    }
                }
            }
        }
    }
}