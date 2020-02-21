namespace Game
{
    public class ToggleGrid2dArray : IToggleGrid
    {
        private readonly bool[,] _cells;

        public ToggleGrid2dArray(Size size)
        {
            Size = size;
            _cells = new bool[size.Width, size.Height];
        }

        public Size Size { get; }

        public bool IsCellSet(Point point)
        {
            if (0 <= point.X && point.X < Size.Width &&
                0 <= point.Y && point.Y < Size.Height)
            {
                return _cells[point.X, point.Y];
            }

            return false;
        }

        public void SetCell(Point point)
        {
            _cells[point.X, point.Y] = true;
        }

        public void UnsetCell(Point point)
        {
            _cells[point.X, point.Y] = false;
        }
    }
}