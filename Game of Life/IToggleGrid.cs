namespace Game
{
    public interface IToggleGrid
    {
        Size Size { get; }

        bool IsCellSet(Point point);

        void SetCell(Point point);

        void UnsetCell(Point point);
    }
}