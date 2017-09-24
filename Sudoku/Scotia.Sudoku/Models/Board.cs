using Scotia.Sudoku.Utils;

namespace Scotia.Sudoku.Models
{
    /// <summary>
    /// A model to represent a Sudoku board, support arbitrary board dimensions and block dimensions as long as rations are 
    /// maintained (ie. board dimensions are multiple of block dimensions)
    /// </summary>
    /// <remarks>
    /// Using byte would be more memory efficient but since arithmetic operators are not defined for byte the rest
    /// of the code would become pretty messy pretty fast.
    /// Using uints which are not CLR compliant so this wouldn't be a wise choise if cross platform support was part of the requirements
    /// </remarks>
    public class Board
    {
        public Board(uint[] digits, BoardDimensions dimensions)
        {
            Guard.IsTrue(digits.Length == dimensions.Height*dimensions.Height,
                "Digits array length must be equals to rowsCount x columnsCount");
            Guard.IsTrue(dimensions.Height >= dimensions.BlockHeight, "height must be greater or equal than blockHeight");
            Guard.IsTrue(dimensions.Width >= dimensions.BlockWidth, "width must be greater or equal than blockWidth");
            Guard.IsTrue(dimensions.Height % dimensions.BlockHeight == 0, "height must be a multiple of blockHeight");
            Guard.IsTrue(dimensions.Width % dimensions.BlockWidth == 0, "width must be a multiple of blockWidth");

            Digits = digits;
            Dimensions = dimensions;
        }

        public uint[] Digits { get; private set; }
        public BoardDimensions Dimensions { get; private set; }
    }
}
