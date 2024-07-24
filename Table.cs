namespace ToyRobotPuzzle
{
    public class Table
    {
        public int Size { get; }

        private Table(int size)
        {
            Size = size;
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }      

        public static Table Create(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than zero.", nameof(size));
            }

            return new Table(size);
        }
    }
}
