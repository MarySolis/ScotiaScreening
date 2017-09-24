using Scotia.Sudoku.ExtensionMethods;
using Scotia.Sudoku.Models;

namespace Scotia.Sudoku
{
    /// <summary>
    /// Verifies if a board is a valid Sudoku solution
    /// </summary>
    public class SolutionVerifier
    {
        #region Public Methods
        
        public bool IsValid(Board aBoard)
        {
            return AllRowsAreValid(aBoard) 
                && AllColumnsAreValid(aBoard)
                && AllBlocksAreValid(aBoard);
        }

        #endregion Public Methods


        #region Private Methods

        private bool AllRowsAreValid(Board aBoard)
        {
            var isValid = true;
            uint rowIndex = 0;

            while (isValid && rowIndex < aBoard.Dimensions.Height)
            {
                isValid = IsBlockValid(aBoard, rowIndex, rowIndex, 0, aBoard.Dimensions.Width.Pred());
                rowIndex ++;
            }

            return isValid;
        }

        private bool AllColumnsAreValid(Board aBoard)
        {
            var isValid = true;
            uint columnIndex = 0;

            while (isValid && columnIndex < aBoard.Dimensions.Width)
            {
                isValid = IsBlockValid(aBoard, 0, ExtensionsMethods.Pred(aBoard.Dimensions.Height), columnIndex, columnIndex);
                columnIndex ++;
            }
            
            return isValid;
        }

	    private bool AllBlocksAreValid(Board aBoard)
	    {
	        var isValid = true;
	        var rowIndex = 0u;
            var columnIndex = 0u;

            //Could have implemented this using two for loops to make it more legible at first glance but this would be against for loop's semantic
	        while (isValid && rowIndex < aBoard.Dimensions.Height)
	        {
                while (isValid && columnIndex < aBoard.Dimensions.Width)
                {
                    isValid = IsBlockValid(aBoard, rowIndex, (rowIndex + aBoard.Dimensions.BlockHeight).Pred(), columnIndex, (columnIndex + aBoard.Dimensions.BlockWidth).Pred());

                    columnIndex += aBoard.Dimensions.BlockWidth;
                }

	            rowIndex += aBoard.Dimensions.BlockHeight;
	        }

            return isValid;
        }

        /// <summary>
        /// A Block is valid if all digits are unique, greater than 0 and their sum is the summatory of N 
        /// </summary>
        private bool IsBlockValid(Board board, uint rowsFirstIndex, uint rowsLastIndex, uint columnsFirstIndex, uint columnsLastIndex)
        {
            var blockSize = (rowsLastIndex - rowsFirstIndex + 1) * (columnsLastIndex - columnsFirstIndex + 1);
            var expectedSum = blockSize * (blockSize + 1) / 2; //Sumatory of all numbers from 1 to n is n(n+1)/2

            //To improve performance, this two extension methods could be collapsed into one, since they both iterate over the same arrays
            //decided against since it would reduce readability and it is unwarranted for such small arrays
            return board.Digits.Sum(rowsFirstIndex, rowsLastIndex, columnsFirstIndex, columnsLastIndex, board.Dimensions.Width) == expectedSum
                && board.Digits.ArrayContainsUniqueNumbers(rowsFirstIndex, rowsLastIndex, columnsFirstIndex, columnsLastIndex, board.Dimensions.Width);
        }

        #endregion Private Methods
    }
}
