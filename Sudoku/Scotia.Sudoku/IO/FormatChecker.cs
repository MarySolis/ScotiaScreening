using System.Linq;
using Scotia.Sudoku.Utils;

namespace Scotia.Sudoku.IO
{
    /// <summary>
    /// Encapsulates the logic to validate if a solution payload is valid
    /// ie. lines are the right lenght and all characters are single digits
    /// Relies in a FileParser for reading from the disk
    /// </summary>
    class FormatChecker
    {
        #region Fields

        private readonly FileParser _parser;
        private readonly uint _lineLength;

        #endregion Fields


        #region Public Methods
        
        public FormatChecker(FileParser parser, uint lineLength)
        {
            Guard.IsNotNull(parser, "parser", "A parser is required");
            _parser = parser;
            _lineLength = lineLength;
        }

        public bool IsValid()
        {
            var content = _parser.LoadContent();
            return content.All(ValidLine);
        }

        #endregion Public Methods


        #region Private Methods
        
        private bool ValidLine(string line)
        {
            Guard.IsNotNull(line, "line", "lines can't not be null");

            return line.Length == _lineLength && line.All(char.IsDigit);
        }

        #endregion Private Methods
    }
}
