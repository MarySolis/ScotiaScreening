using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scotia.Sudoku.IO;

namespace SolutionVerifier.Tests
{
    [TestClass]
    public class FileParsingTests
    {
        [TestMethod]
        public void ShouldParseProperlyFormattedFiles()
        {
            //More examples available at: http://elmo.sbs.arizona.edu/sandiway/sudoku/examples.html
            var files = new[] { @".\Resources\Ok\input_sudoku.txt", @".\Resources\Ok\input_killer_sudoku.txt", @".\Resources\Ok\input_diabolical.txt" };

            Func<string, bool> func = s =>
                {
                    var checker = new FormatChecker(new FileParser(s), 9);
                    return checker.IsValid();
                };

            AssertFunctionResultIsTrue(files, func);
        }

        [TestMethod]
        public void ShouldIgnoreOptionalEmptyLines()
        {
            const string fileNameNoBlankLines = @".\Resources\Ok\input_sudoku_blanks_optional.txt";
            var checkerNoBlankLines = new FormatChecker(new FileParser(fileNameNoBlankLines), 9);

            Assert.IsTrue(checkerNoBlankLines.IsValid());
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void ShouldFailWithMissingFile()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_missing_file.txt";
            var checker = new FormatChecker(new FileParser(fileName), 9);

            Assert.IsFalse(checker.IsValid());
        }

        [TestMethod]
        public void ShouldFailWithLetters()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_letter.txt";
            var checker = new FormatChecker(new FileParser(fileName), 9);
            
            Assert.IsFalse(checker.IsValid());
        }

        [TestMethod]
        public void ShouldFailWithAnExtraDigit()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_extra_digit.txt";
            var checker = new FormatChecker(new FileParser(fileName), 9);

            Assert.IsFalse(checker.IsValid());
        }

        [TestMethod]
        public void ShouldFailWithAMissingDigit()
        {
            const string fileName = @".\Resources\Fail\input_sudoku_missing_digit.txt";
            var checker = new FormatChecker(new FileParser(fileName), 9);

            Assert.IsFalse(checker.IsValid());
        }

        [TestMethod]
        //Initally planned to have more unit tests testing against multiple files, ended with only one so this
        //now seems like a piece of over-engineering
        private void AssertFunctionResultIsTrue<T>(T[] inputs, Func<T, bool> func)
        {
            foreach (var input in inputs)
            {
                Assert.IsTrue(func(input));
            }
        }
    }
}
