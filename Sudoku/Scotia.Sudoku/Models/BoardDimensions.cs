namespace Scotia.Sudoku.Models
{
    public struct BoardDimensions
    {
        public BoardDimensions(uint width, uint height, uint blockWidth, uint blockHeight) : this()
        {
            Width = width;
            Height = height;
            BlockWidth = blockWidth;
            BlockHeight = blockHeight;
        }

        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint BlockWidth { get; private set; }
        public uint BlockHeight { get; private set; }
    }
}