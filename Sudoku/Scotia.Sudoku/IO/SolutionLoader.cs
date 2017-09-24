using System;
using System.IO;
using System.Linq;
using Scotia.Sudoku.Models;
using Scotia.Sudoku.Utils;

namespace Scotia.Sudoku.IO
{
    /// <summary>
    /// Encapsulates loading a sudoku board from a file name, delegates to FileParser and FormatChecker for IO and validation
    /// In a realistic scenario this dependencies would be injected by a DI framework
    /// </summary>
    public class SolutionLoader
    {
        #region Fields
        
        private readonly string _fileName;
        private BoardDimensions _dimensions;

        #endregion Fields


        #region Public Methods

        public SolutionLoader(string fileName, BoardDimensions dimensions)
        {
            Guard.IsTrue(dimensions.Width*dimensions.Height*dimensions.BlockWidth*dimensions.BlockHeight != 0, "All Board dimensions must be greater than zero");

            //Do not check if the file exists and has a valid format until the board is loaded (lazy approach)
            _fileName = fileName;
            _dimensions = dimensions;
        }

        public Board GetBoard()
        {
            var parser = new FileParser(_fileName);
            var checker = new FormatChecker(parser, _dimensions.Width);

            if (!checker.IsValid())
            {
                throw new FileLoadException("Invalid file format detected.");
            }

            var cursor = 0;
            var fileContent = parser.LoadContent();

            var digits = new uint[fileContent.Length * _dimensions.Width];
            foreach (var line in fileContent)
            {
                var uintArray = line.ToCharArray().Select(c => uint.Parse(c.ToString())).ToArray();
                Array.Copy(uintArray, 0, digits, cursor, uintArray.Length);
                cursor += uintArray.Length;
            }

            return new Board(digits, _dimensions);
        }

        #endregion Public Methods
    }
}
