using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scotia.Sudoku.IO;
using Scotia.Sudoku.Models;

namespace SolutionVerifier.Tests
{
    [TestClass]
    public class SudokuRulesTests
    {
        #region Happy Paths

        [TestMethod]
        public void ShouldSucceedWithValidSolutions()
        {
            const string fileName = @".\Resources\Ok\input_sudoku.txt";
            var input = new SolutionLoader(fileName, new BoardDimensions(9, 9, 3, 3));
            var verifier = new Scotia.Sudoku.SolutionVerifier();

            Assert.IsTrue(verifier.IsValid(input.GetBoard()));
        }

        #endregion Happy Paths


        #region Edge Cases
        
        [TestMethod]
        public void ShouldFailWithDuplicateInRow()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_duplicate_in_row.txt";
            var input = new SolutionLoader(fileName, new BoardDimensions(9, 9, 3, 3));
            var verifier = new Scotia.Sudoku.SolutionVerifier();

            Assert.IsFalse(verifier.IsValid(input.GetBoard()));
        }

        [TestMethod]
        public void ShouldFailWithDuplicateInColumn()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_duplicate_in_column.txt";
            var input = new SolutionLoader(fileName, new BoardDimensions(9, 9, 3, 3));
            var verifier = new Scotia.Sudoku.SolutionVerifier();

            Assert.IsFalse(verifier.IsValid(input.GetBoard()));
        }

        [TestMethod]
        public void ShouldFailWithDuplicateValueInBlock()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_duplicate_in_block.txt";
            var input = new SolutionLoader(fileName, new BoardDimensions(9, 9, 3, 3));
            var verifier = new Scotia.Sudoku.SolutionVerifier();

            Assert.IsFalse(verifier.IsValid(input.GetBoard()));
        }

        #endregion Edge Cases
    }
}
